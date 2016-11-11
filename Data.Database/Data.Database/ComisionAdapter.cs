using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using System.Data;
using System.Data.SqlClient;



namespace Data.Database
{
    public class ComisionAdapter : Adapter
    {

        public List<Comision> GetAll()
        {
            List<Comision> comisiones = new List<Comision>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdComisiones = new SqlCommand("SELECT * FROM comisiones", SqlConn);
                SqlDataReader drComisiones = cmdComisiones.ExecuteReader();
                while (drComisiones.Read())
                {
                    Comision comision = new Comision();

                    comision.ID = (int)drComisiones["id_comision"];
                    comision.Descripcion = (string)drComisiones["desc_comision"];
                    comision.AnioEspecialidad = (int)drComisiones["anio_especialidad"];
                    comision.IDPlan = (int)drComisiones["id_plan"];

                    comisiones.Add(comision);
                }

                drComisiones.Close();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de comisiones", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return comisiones;
        }


        public Entidades.Comision GetOne(int ID)
        {
            Comision comision = new Comision();
            try
            {
                this.OpenConnection();
                SqlCommand cmdComisiones = new SqlCommand("SELECT * FROM comisiones WHERE id_comision = @id", SqlConn);
                cmdComisiones.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drComisiones = cmdComisiones.ExecuteReader();
                if (drComisiones.Read())
                {
                    comision.ID = (int)drComisiones["id_comision"];
                    comision.Descripcion = (string)drComisiones["desc_comision"];
                    comision.AnioEspecialidad = (int)drComisiones["anio_especialidad"];
                    comision.IDPlan = (int)drComisiones["id_plan"];
                }

                drComisiones.Close();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return comision;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("DELETE comisiones WHERE id_comision = @id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar el comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(Comision comision)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE comisiones SET desc_comision = @desc_comision, anio_especialidad = @anio_especialidad," +
                                                    "id_plan = @id_plan" +
                                                    "WHERE id_comision = @id", SqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = comision.ID;
                cmdSave.Parameters.Add("@desc_comision", SqlDbType.VarChar, 50).Value = comision.Descripcion;
                cmdSave.Parameters.Add("@anio_especialidad", SqlDbType.Int).Value = comision.AnioEspecialidad;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = comision.IDPlan;

                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del comision", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(Comision comision)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("INSERT INTO comisiones (desc_comision,anio_especialidad,id_plan) " +
                                                    "VALUES(@desc_comision,@anio_especialidad,id_plan) " +
                                                    "SELECT @@identity", SqlConn);


                cmdSave.Parameters.Add("@desc_comision", SqlDbType.VarChar, 50).Value = comision.Descripcion;
                cmdSave.Parameters.Add("@anio_especialidad", SqlDbType.Int).Value = comision.AnioEspecialidad;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = comision.IDPlan;

                comision.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar()); //Asi se obtiene el id que asingo a la BD automaticamente

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear comision", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Comision comision)
        {
            if (comision.State == Entidades.Entidades.States.Deleted)
            {
                this.Delete(comision.ID);
            }
            else if (comision.State == Entidades.Entidades.States.New)
            {
                this.Insert(comision);
            }
            else if (comision.State == Entidades.Entidades.States.Modified)
            {
                this.Update(comision);
            }
            comision.State = Entidades.Entidades.States.Unmodified;
        }
    }
}

