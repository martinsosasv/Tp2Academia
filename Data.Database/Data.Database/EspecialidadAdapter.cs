using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace Data.Database
{
    public class EspecialidadAdapter : Adapter
    {
        public List<Especialidad> GetAll()
        {
            List<Especialidad> especialidades = new List<Especialidad>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdEspecialidades = new SqlCommand("SELECT * FROM especialidades", SqlConn);
                SqlDataReader drEspecialidades = cmdEspecialidades.ExecuteReader();
                while (drEspecialidades.Read())
                {
                    Especialidad especialidad = new Especialidad();

                    especialidad.ID = (int)drEspecialidades["id_especialidad"];
                    especialidad.Descripcion = (string)drEspecialidades["desc_especialidad"];

                    especialidades.Add(especialidad);
                }

                drEspecialidades.Close();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de especialidades", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return especialidades;
        }


        public Entidades.Especialidad GetOne(int ID)
        {
            Especialidad esp = new Especialidad();
            try
            {
                this.OpenConnection();
                SqlCommand cmdEspecialidades = new SqlCommand("SELECT * FROM especialidades WHERE id_especialidad = @id", SqlConn);
                cmdEspecialidades.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drEspecialidades = cmdEspecialidades.ExecuteReader();
                if (drEspecialidades.Read())
                {
                    esp.ID = (int)drEspecialidades["id_especialidad"];
                    esp.Descripcion = (string)drEspecialidades["desc_especialidad"];
                }

                drEspecialidades.Close();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de la especialidad", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return esp;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("DELETE especialidades WHERE id_especialidad = @id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar la especialidad", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Update(Especialidad especialidad)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE especialidades SET desc_especialidad = @desc_especialidad" +
                                                    "WHERE id_especialidad = @id", SqlConn);
                cmdSave.Parameters.AddWithValue("@id", Convert.ToInt32(especialidad.ID));
                cmdSave.Parameters.AddWithValue("@desc_especialidad",especialidad.Descripcion);
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de la especialidad", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Insert(Especialidad especialidad)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("INSERT INTO especialidades (desc_especialidad) " +
                                                    "VALUES(@desc_especialidad)" +
                                                    "SELECT @@identity", SqlConn);

                cmdSave.Parameters.Add("@desc_especialidad", SqlDbType.VarChar, 50).Value = especialidad.Descripcion;
                especialidad.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar()); //Asi se obtiene el id que asingo a la BD automaticamente

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear especialidad", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Especialidad especialidad)
        {
            if (especialidad.State == Entidades.Entidades.States.Deleted)
            {
                this.Delete(especialidad.ID);
            }
            else if (especialidad.State == Entidades.Entidades.States.New)
            {
                this.Insert(especialidad);
            }
            else if (especialidad.State == Entidades.Entidades.States.Modified)
            {
                this.Update(especialidad);
            }
            especialidad.State = Entidades.Entidades.States.Unmodified;
        }
    }
}
