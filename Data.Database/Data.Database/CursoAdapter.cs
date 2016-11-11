using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using System.Data;
using System.Data.SqlClient;



namespace Data.Database
{
    public class CursoAdapter : Adapter
    {

        public List<Curso> GetAll()
        {
            List<Curso> cursos = new List<Curso>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdCursos = new SqlCommand("SELECT * FROM cursos", SqlConn);
                SqlDataReader drCursos = cmdCursos.ExecuteReader();
                while (drCursos.Read())
                {
                    Curso curso = new Curso();

                    curso.ID = (int)drCursos["id_curso"];
                    curso.IdMateria = (int)drCursos["id_materia"];
                    curso.IdComision = (int)drCursos["id_comision"];
                    curso.AnioCalendario = (int)drCursos["anio_calendario"];
                    curso.Cupo = (int)drCursos["cupo"];

                    cursos.Add(curso);
                }

                drCursos.Close();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de cursos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return cursos;
        }


        public Entidades.Curso GetOne(int ID)
        {
            Curso curso = new Curso();
            try
            {
                this.OpenConnection();
                SqlCommand cmdCursos = new SqlCommand("SELECT * FROM cursos WHERE id_curso = @id", SqlConn);
                cmdCursos.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drCursos = cmdCursos.ExecuteReader();
                if (drCursos.Read())
                {
                    curso.ID = (int)drCursos["id_curso"];
                    curso.IdMateria = (int)drCursos["id_materia"];
                    curso.IdComision = (int)drCursos["id_comision"];
                    curso.AnioCalendario = (int)drCursos["anio_calendario"];
                    curso.Cupo = (int)drCursos["anio_calendario"];
                }

                drCursos.Close();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return curso;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("DELETE cursos WHERE id_curso = @id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar el curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(Curso curso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE cursos SET id_materia = @id_materia, id_comision = @id_comision," +
                                                    "anio_calendario = @anio_calendario, cupo = @cupo" +
                                                    "WHERE id_curso = @id", SqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = curso.ID;
                cmdSave.Parameters.Add("@id_materia", SqlDbType.Int).Value = curso.IdMateria;
                cmdSave.Parameters.Add("@id_comision", SqlDbType.Int).Value = curso.IdComision;
                cmdSave.Parameters.Add("@anio_calendario", SqlDbType.Int).Value = curso.AnioCalendario;
                cmdSave.Parameters.Add("@cupo", SqlDbType.Int).Value = curso.Cupo;

                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del curso", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(Curso curso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("INSERT INTO cursos (id_materia,id_comision,,cupo) " +
                                                    "VALUES(@id_materia,@id_comision,@anio_calendario,@cupo) " +
                                                    "SELECT @@identity", SqlConn);


                cmdSave.Parameters.Add("@id_materia", SqlDbType.Int).Value = curso.IdMateria;
                cmdSave.Parameters.Add("@id_comision", SqlDbType.Int).Value = curso.IdComision;
                cmdSave.Parameters.Add("@anio_calendario", SqlDbType.Int).Value = curso.AnioCalendario;
                cmdSave.Parameters.Add("@cupo", SqlDbType.Int).Value = curso.Cupo;

                curso.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar()); //Asi se obtiene el id que asingo a la BD automaticamente

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear curso", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Curso curso)
        {
            if (curso.State == Entidades.Entidades.States.Deleted)
            {
                this.Delete(curso.ID);
            }
            else if (curso.State == Entidades.Entidades.States.New)
            {
                this.Insert(curso);
            }
            else if (curso.State == Entidades.Entidades.States.Modified)
            {
                this.Update(curso);
            }
            curso.State = Entidades.Entidades.States.Unmodified;
        }
    }
}
