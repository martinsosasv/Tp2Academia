using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using System.Data;
using System.Data.SqlClient;



namespace Data.Database
{
    public class DocenteCursoAdapter : Adapter
    {

        public List<DocenteCurso> GetAll()
        {
            List<DocenteCurso> docentes = new List<DocenteCurso>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdDocenteCursoes = new SqlCommand("SELECT * FROM docentes_cursos", SqlConn);
                SqlDataReader drDocenteCursoes = cmdDocenteCursoes.ExecuteReader();
                while (drDocenteCursoes.Read())
                {
                    DocenteCurso doc = new DocenteCurso();

                    doc.ID = (int)drDocenteCursoes["id_dictado"];
                    doc.IdCurso = (int)drDocenteCursoes["id_curso"];
                    doc.IdDocente = (int)drDocenteCursoes["id_docente"];
                    doc.Cargo = (int)drDocenteCursoes["cargo"];

                    docentes.Add(doc);
                }

                drDocenteCursoes.Close();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de docentes cursos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return docentes;
        }

        // Lista todos los docentes de un curso
        public List<DocenteCurso> GetCursoDocentes(int IDCurso)
        {
            List<DocenteCurso> cursoDocentes = new List<DocenteCurso>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdCursoDocentes = new SqlCommand("SELECT * FROM docentes_cursos WHERE id_curso = @id_curso", SqlConn);
                cmdCursoDocentes.Parameters.Add("@id_curso", SqlDbType.Int).Value = IDCurso;
                SqlDataReader drDatosCurso = cmdCursoDocentes.ExecuteReader();
                if (drDatosCurso.Read())
                {
                    DocenteCurso docente = new DocenteCurso();

                    docente.ID = (int)drDatosCurso["id_dictado"];
                    docente.IdCurso = (int)drDatosCurso["id_curso"];
                    docente.IdDocente = (int)drDatosCurso["id_docente"];
                    docente.Cargo = (int)drDatosCurso["cargo"];

                    cursoDocentes.Add(docente);

                }

                drDatosCurso.Close();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de inscripciones curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return cursoDocentes;
        }

        // Lista todos los cursos para un docente
        public List<DocenteCurso> GetDocenteCursos(int IDDocente)
        {
            List<DocenteCurso> cursoDocentes = new List<DocenteCurso>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdCursosDocente = new SqlCommand("SELECT * FROM docentes_cursos WHERE id_docente = @id_docente", SqlConn);
                cmdCursosDocente.Parameters.Add("@id_docente", SqlDbType.Int).Value = IDDocente;
                SqlDataReader drCursosDocentes = cmdCursosDocente.ExecuteReader();
                if (drCursosDocentes.Read())
                {
                    DocenteCurso docente = new DocenteCurso();

                    docente.ID = (int)drCursosDocentes["id_dictado"];
                    docente.IdCurso = (int)drCursosDocentes["id_curso"];
                    docente.IdDocente = (int)drCursosDocentes["id_docente"];
                    docente.Cargo = (int)drCursosDocentes["cargo"];

                    cursoDocentes.Add(docente);

                }

                drCursosDocentes.Close();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de cursos docente", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return cursoDocentes;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("DELETE docentes_cursos WHERE id_dictado = @id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar curso docente", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(DocenteCurso cursoDocente)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE alumnos_inscripcion SET id_curso = @id_curso, id_docente = @id_docente," +
                                                    "cargo = @cargo" +
                                                    "WHERE id_dictado = @id_dictado", SqlConn);
                cmdSave.Parameters.Add("@id_dictado", SqlDbType.Int).Value = cursoDocente.ID;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = cursoDocente.IdCurso;
                cmdSave.Parameters.Add("@id_docente", SqlDbType.Int).Value = cursoDocente.IdDocente;
                cmdSave.Parameters.Add("@cargo", SqlDbType.Int).Value = cursoDocente.Cargo;


                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de docente curso", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(DocenteCurso docenteCurso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("INSERT INTO alumnos_inscripcion (id_curso,id_docente,cargo) " +
                                                    "VALUES(@id_curso,@id_docente,@cargo) " +
                                                    "SELECT @@identity", SqlConn);

                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = docenteCurso.IdCurso;
                cmdSave.Parameters.Add("@id_docente", SqlDbType.Int).Value = docenteCurso.IdDocente;
                cmdSave.Parameters.Add("@cargo", SqlDbType.Int).Value = docenteCurso.Cargo;
                docenteCurso.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar()); //Asi se obtiene el id que asingo a la BD automaticamente

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear docente curso", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(DocenteCurso inscripcion)
        {
            if (inscripcion.State == Entidades.Entidades.States.Deleted)
            {
                this.Delete(inscripcion.ID);
            }
            else if (inscripcion.State == Entidades.Entidades.States.New)
            {
                this.Insert(inscripcion);
            }
            else if (inscripcion.State == Entidades.Entidades.States.Modified)
            {
                this.Update(inscripcion);
            }
            inscripcion.State = Entidades.Entidades.States.Unmodified;
        }
    }
}
