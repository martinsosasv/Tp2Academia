using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using System.Data;
using System.Data.SqlClient;



namespace Data.Database
{
    public class PlanAdapter : Adapter
    {

        public List<Plan> GetAll()
        {
            List<Plan> planes = new List<Plan>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdPlanes = new SqlCommand("SELECT id_plan, desc_plan, id_especialidad FROM planes", SqlConn);
                SqlDataReader drPlanes = cmdPlanes.ExecuteReader();
                while (drPlanes.Read())
                {
                    Plan plan = new Plan();
                    EspecialidadAdapter espAda = new EspecialidadAdapter();
                    Especialidad especialidad = new Especialidad();
                    especialidad = espAda.GetOne(Convert.ToInt32(drPlanes[2]));
                    

                    plan.ID = (int)drPlanes["id_plan"];
                    plan.Descripcion = (string)drPlanes["desc_plan"];
                    plan.Especialidad = drPlanes.IsDBNull(2) ? null : especialidad;
                    
                    planes.Add(plan);
                }

                drPlanes.Close();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de planes", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return planes;
        }


        public Entidades.Plan GetOne(int ID)
        {
            Plan plan = new Plan();
            try
            {
                this.OpenConnection();
                SqlCommand cmdPlanes = new SqlCommand("SELECT id_plan, desc_plan, id_especialidad FROM planes WHERE id_plan = @id", SqlConn);
                cmdPlanes.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drPlanes = cmdPlanes.ExecuteReader();
                if (drPlanes.Read())
                {
                    
                    EspecialidadAdapter espAda = new EspecialidadAdapter();
                    Especialidad especialidad = new Especialidad();
                    especialidad = espAda.GetOne(Convert.ToInt32(drPlanes[2]));

                    plan.ID = (int)drPlanes["id_plan"];
                    plan.Descripcion = (string)drPlanes["desc_plan"];
                    plan.Especialidad = drPlanes.IsDBNull(2) ? null : especialidad;

                }

                drPlanes.Close();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de plan", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return plan;
        }

        public void Delete(Plan plan)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("DELETE planes WHERE id_plan = @id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = plan.ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar el plan", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Update(Plan plan)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE planes SET desc_plan = @desc_plan," +
                                                    "id_especialidad = @id_especialidad" +
                                                    "WHERE id_plan = @id", SqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = plan.ID;
                cmdSave.Parameters.Add("@desc_plan", SqlDbType.VarChar, 50).Value = plan.Descripcion;
                cmdSave.Parameters.Add("@id_especilidad", SqlDbType.VarChar, 50).Value = plan.Especialidad.ID;

                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del plan", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Insert(Plan plan)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("INSERT INTO planes (desc_plan,id_especialidad) " +
                                                    "VALUES(@desc_plan,@id_especialidad) " +
                                                    "SELECT @@identity", SqlConn);


                cmdSave.Parameters.Add("@desc_plan", SqlDbType.VarChar, 50).Value = plan.Descripcion;
                cmdSave.Parameters.Add("@id_especialidad", SqlDbType.Int).Value = plan.Especialidad.ID;

                plan.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar()); //Asi se obtiene el id que asingo a la BD automaticamente

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear plan", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }

        /*public void Save(Plan plan)
        {
            if (plan.State == Entidades.Entidades.States.Deleted)
            {
                this.Delete(plan.ID);
            }
            else if (plan.State == Entidades.Entidades.States.New)
            {
                this.Insert(plan);
            }
            else if (plan.State == Entidades.Entidades.States.Modified)
            {
                this.Update(plan);
            }
            plan.State = Entidades.Entidades.States.Unmodified;
        }*/
    }
}
