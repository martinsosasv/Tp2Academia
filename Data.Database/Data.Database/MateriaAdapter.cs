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
    public class MateriaAdapter : Adapter
    {
        public List<Materia> GetAll()
        {
            List<Materia> materias = new List<Materia>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdMaterias = new SqlCommand("SELECT id_materia, desc_materia, hs_semanales, hs_totales, id_plan FROM materias WHERE 1=1", SqlConn);
                SqlDataReader drMaterias = cmdMaterias.ExecuteReader();
                while (drMaterias.Read())
                {
                    Materia materia = new Materia();
                    PlanAdapter plaAda = new PlanAdapter();
                    Plan plan = new Plan();
                    plan = plaAda.GetOne(Int32.Parse(drMaterias["id_plan"].ToString()));

                    //EspecialidadAdapter espAda = new EspecialidadAdapter();
                    //Especialidad espe = new Especialidad();
                    //espe = espAda.GetOne(plan.ID);


                    materia.ID = (int)drMaterias["id_materia"];
                    materia.Descripcion = (string)drMaterias["desc_materia"];
                    materia.HSSemanales = (int)drMaterias["hs_semanales"];
                    materia.HSTotales = (int)drMaterias["hs_totales"];
                    materia.Plan = drMaterias.IsDBNull(4) ? null : plan ;
                    //materia.DescripcionPlan = plan.Descripcion.ToString();
                    //materia.DescripcionEspecPlan = espe.Descripcion.ToString();
                    materias.Add(materia);
                }

                drMaterias.Close();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de materias", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return materias;
        }

        public Materia GetOne(int ID)
        {
            Materia materia = new Materia();
            try
            {
                this.OpenConnection();
                SqlCommand cmdMateria = new SqlCommand("SELECT id_materia, desc_materia, hs_semanales, hs_totales, id_plan FROM materias WHERE id_materia = @id", SqlConn);
                cmdMateria.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drMateria = cmdMateria.ExecuteReader();
                if (drMateria.Read())
                {
                    PlanAdapter plaAda = new PlanAdapter();
                    Plan plan = new Plan();
                    plan = plaAda.GetOne(Convert.ToInt32(drMateria["id_plan"]));

                    EspecialidadAdapter espAda = new EspecialidadAdapter();
                    Especialidad espe = new Especialidad();
                    espe = espAda.GetOne(plan.ID);

                    materia.ID = (int)drMateria["id_materia"];
                    materia.Descripcion = (string)drMateria["desc_materia"];
                    materia.HSSemanales = (int)drMateria["hs_semanales"];
                    materia.HSTotales = (int)drMateria["hs_totales"];
                    materia.Plan = drMateria.IsDBNull(4) ? null : plan;
                    materia.Plan.Especialidad = espe;
                    //materia.DescripcionPlan = plan.Descripcion.ToString();
                    //materia.DescripcionEspecPlan = espe.Descripcion.ToString();
                }

                drMateria.Close();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de la materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return materia;
        }

        public void Delete(Materia materia)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("DELETE materias WHERE id_materia = @id", SqlConn);
                cmdDelete.Parameters.AddWithValue("@id",materia.ID);
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar la materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Update(Materia materia)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE materias SET desc_materia = @desc_materia, hs_semanales = @hs_semanales," +
                                                    "hs_totales = @hs_totales, id_plan = @id_plan" +
                                                    "WHERE id_materia = @id", SqlConn);
                cmdSave.Parameters.AddWithValue("@desc_materia",materia.Descripcion);
                cmdSave.Parameters.AddWithValue("@hs_semanales",materia.HSSemanales);
                cmdSave.Parameters.AddWithValue("@hs_totales",materia.HSTotales);
                cmdSave.Parameters.AddWithValue("@id_plan",materia.Plan.ID);
                cmdSave.Parameters.AddWithValue("@id",materia.ID);
                

                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de la materia", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Insert(Materia materia)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("INSERT INTO materias (desc_materia,hs_semanales,hs_totales,id_plan) " +
                                                    "VALUES(@desc_materia,@hs_semanales,@hs_totales,@id_plan) " +
                                                    "SELECT @@identity", SqlConn);

                cmdSave.Parameters.AddWithValue("@desc_materia", materia.Descripcion);
                cmdSave.Parameters.AddWithValue("@hs_semanales", materia.HSSemanales);
                cmdSave.Parameters.AddWithValue("@hs_totales", materia.HSTotales);
                cmdSave.Parameters.AddWithValue("@id_plan", materia.Plan.ID);
                materia.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar()); //Asi se obtiene el id que asingo a la BD automaticamente

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear materia", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }
    }
}
