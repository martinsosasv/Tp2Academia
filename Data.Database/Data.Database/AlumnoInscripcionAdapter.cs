using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using System.Data;
using System.Data.SqlClient;



namespace Data.Database
{
    public class AlumnoInscripcionAdapter : Adapter
    {

        public List<AlumnoInscripcion> GetAll()
        {
            List<AlumnoInscripcion> alumnos = new List<AlumnoInscripcion>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdAlumnoInscripciones = new SqlCommand("SELECT * FROM alumnos_incripciones", SqlConn);
                SqlDataReader drAlumnoInscripciones = cmdAlumnoInscripciones.ExecuteReader();
                while (drAlumnoInscripciones.Read())
                {
                    AlumnoInscripcion alu = new AlumnoInscripcion();

                    alu.ID = (int)drAlumnoInscripciones["id_inscripcion"];
                    alu.IdAlumno = (int)drAlumnoInscripciones["id_usuario"];
                    alu.IdCurso = (int)drAlumnoInscripciones["nombre_usuario"];
                    alu.Condicion = (string)drAlumnoInscripciones["clave"];
                    alu.Nota = (int)drAlumnoInscripciones["nota"];

                    alumnos.Add(alu);
                }

                drAlumnoInscripciones.Close();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de inscripciones alumnos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return alumnos;
        }


        public List<AlumnoInscripcion> GetInscripcionesCurso(int IDCurso)
        {
            List<AlumnoInscripcion> inscripcionesCursos = new List<AlumnoInscripcion>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdDatosCurso = new SqlCommand("SELECT * FROM alumnos_inscripciones WHERE id_curso = @id_curso", SqlConn);
                cmdDatosCurso.Parameters.Add("@id_curso", SqlDbType.Int).Value = IDCurso;
                SqlDataReader drDatosCurso = cmdDatosCurso.ExecuteReader();
                if (drDatosCurso.Read())
                {
                    AlumnoInscripcion aluCurso = new AlumnoInscripcion();

                    aluCurso.ID = (int)drDatosCurso["id_inscripcion"];
                    aluCurso.IdAlumno = (int)drDatosCurso["id_usuario"];
                    aluCurso.IdCurso = (int)drDatosCurso["nombre_usuario"];
                    aluCurso.Condicion = (string)drDatosCurso["clave"];
                    aluCurso.Nota = (int)drDatosCurso["nota"];

                    inscripcionesCursos.Add(aluCurso);

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
            return inscripcionesCursos;
        }

        public List<AlumnoInscripcion> GetInscripcionesAlumno(int IDAlumno)
        {
            List<AlumnoInscripcion> inscripcionesCursos = new List<AlumnoInscripcion>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdDatosCurso = new SqlCommand("SELECT * FROM alumnos_inscripciones WHERE id_alumno = @id_alumno", SqlConn);
                cmdDatosCurso.Parameters.Add("@id_curso", SqlDbType.Int).Value = IDAlumno;
                SqlDataReader drDatosCurso = cmdDatosCurso.ExecuteReader();
                if (drDatosCurso.Read())
                {
                    AlumnoInscripcion aluCurso = new AlumnoInscripcion();

                    aluCurso.ID = (int)drDatosCurso["id_inscripcion"];
                    aluCurso.IdAlumno = (int)drDatosCurso["id_usuario"];
                    aluCurso.IdCurso = (int)drDatosCurso["nombre_usuario"];
                    aluCurso.Condicion = (string)drDatosCurso["clave"];
                    aluCurso.Nota = (int)drDatosCurso["nota"];

                    inscripcionesCursos.Add(aluCurso);

                }

                drDatosCurso.Close();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de inscripciones alumno", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return inscripcionesCursos;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("DELETE alumnos_inscripciones WHERE id_inscripcion = @id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar el usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(AlumnoInscripcion inscripcion)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE alumnos_inscripcion SET id_curso = @id_curso, id_alumno = @id_alumno," +
                                                    "condicion = @condicion, nota = @nota" +
                                                    "WHERE id_inscripcion = @id_inscripcion", SqlConn);
                cmdSave.Parameters.Add("@id_inscripcion", SqlDbType.Int).Value = inscripcion.ID;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = inscripcion.IdCurso;
                cmdSave.Parameters.Add("@id_alumno", SqlDbType.Int).Value = inscripcion.IdAlumno;
                cmdSave.Parameters.Add("@condicion", SqlDbType.VarChar, 50).Value = inscripcion.Condicion;
                cmdSave.Parameters.Add("@nota", SqlDbType.Int).Value = inscripcion.Nota;


                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de inscripcion", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(AlumnoInscripcion inscripcion)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("INSERT INTO alumnos_inscripcion (id_curso,id_alumno,condicion,nota) " +
                                                    "VALUES(@id_curso,@id_alumno,@condicion,@nota) " +
                                                    "SELECT @@identity", SqlConn);

                cmdSave.Parameters.Add("@id_alumno", SqlDbType.Int).Value = inscripcion.IdAlumno;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = inscripcion.IdCurso;
                cmdSave.Parameters.Add("@condicion", SqlDbType.VarChar, 50).Value = inscripcion.Condicion;
                cmdSave.Parameters.Add("@nota", SqlDbType.Int).Value = inscripcion.Nota;
                inscripcion.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar()); //Asi se obtiene el id que asingo a la BD automaticamente

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear usuario", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(AlumnoInscripcion inscripcion)
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
