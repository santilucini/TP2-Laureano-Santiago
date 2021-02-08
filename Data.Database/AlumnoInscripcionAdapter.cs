using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace Data.Database
{
    public class AlumnoInscripcionAdapter : Adapter
    {
        public List<AlumnoInscripcion> GetAll()
        {
            List<AlumnoInscripcion> inscripcion = new List<AlumnoInscripcion>();

            try
            {
                this.OpenConnection();

                SqlCommand cmdInscripcion = new SqlCommand("select * from alumnos_inscripciones", sqlConn);

                SqlDataReader drInscripcion = cmdInscripcion.ExecuteReader();

                while (drInscripcion.Read())
                {
                    AlumnoInscripcion ins = new AlumnoInscripcion();

                    ins.ID = (int)drInscripcion["id_inscripcion"];

                    ins.Alumno = new PersonasAdapter().GetOne((int)drInscripcion["id_alumno"]);
                    ins.Curso = new CursoAdapter().GetOne((int)drInscripcion["id_curso"]);

                    /* CORREGIDO ARRIBA
                    ins.IDAlumno = (int)drInscripcion["id_alumno"];
                    ins.IDCurso = (int)drInscripcion["id_curso"];
                    */
                    ins.Condicion = (string)drInscripcion["condicion"];
                    

                    // Validar que la nota no sea null
                    if (String.IsNullOrEmpty(drInscripcion["nota"].ToString()))
                    {
                        ins.Nota = 0;
                    }
                    else
                    {
                        ins.Nota = (int)drInscripcion["nota"];
                    }

                    inscripcion.Add(ins);
                }

                drInscripcion.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Erro al recuperar lista de Alumnos inscriptos", Ex);

                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return inscripcion;
        }

        public List<AlumnoInscripcion> GetInscripcionesDocente(Usuario usuario)
        {
            List<AlumnoInscripcion> Inscripciones = new List<AlumnoInscripcion>();
            try
            {
                OpenConnection();
                SqlCommand cmdDocenteInscripcion = new SqlCommand("select * from docentes_cursos dc inner join " +
                "alumnos_inscripciones ai on ai.id_curso=dc.id_curso where dc.id_docente=@idDocente", sqlConn);
                cmdDocenteInscripcion.Parameters.Add("@idDocente", SqlDbType.Int).Value = usuario.Persona.ID;
                SqlDataReader drInscripciones = cmdDocenteInscripcion.ExecuteReader();
                while (drInscripciones.Read())
                {
                    AlumnoInscripcion AlIns = new AlumnoInscripcion();
                    AlIns.Alumno = new PersonasAdapter().GetOne((int)drInscripciones["id_alumno"]);
                    AlIns.ID = (int)drInscripciones["id_inscripcion"];
                    //Objeto Curso
                    AlIns.Curso = new CursoAdapter().GetOne((int)drInscripciones["id_curso"]);
                    AlIns.Condicion = (string)drInscripciones["condicion"];
                    //Por si las notas no fueron cargadas
                    if (String.IsNullOrEmpty(drInscripciones["nota"].ToString()))
                    {
                        AlIns.Nota = 0;
                    }
                    else
                    {
                        AlIns.Nota = (int)drInscripciones["nota"];
                    }
                    Inscripciones.Add(AlIns);
                }
                drInscripciones.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de Inscripciones", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
            return Inscripciones;
        }

        public List<AlumnoInscripcion> GetInscripcionesAlumno(Usuario usuario)
        {
            List<AlumnoInscripcion> Inscripciones = new List<AlumnoInscripcion>();
            try
            {
                OpenConnection();
                SqlCommand cmdAlumnoInscripcion = new SqlCommand("select * from alumnos_inscripciones where id_alumno=@idAlumno", sqlConn);
                cmdAlumnoInscripcion.Parameters.Add("@idAlumno", SqlDbType.Int).Value = usuario.Persona.ID;
                SqlDataReader drInscripciones = cmdAlumnoInscripcion.ExecuteReader();
                while (drInscripciones.Read())
                {
                    AlumnoInscripcion AlIns = new AlumnoInscripcion();
                    AlIns.Alumno = new PersonasAdapter().GetOne((int)drInscripciones["id_alumno"]);
                    AlIns.ID = (int)drInscripciones["id_inscripcion"];
                    //Objeto Curso
                    AlIns.Curso = new CursoAdapter().GetOne((int)drInscripciones["id_curso"]);
                    AlIns.Condicion = (string)drInscripciones["condicion"];
                    //Por si las notas no fueron cargadas
                    if (String.IsNullOrEmpty(drInscripciones["nota"].ToString()))
                    {
                        AlIns.Nota = 0;
                    }
                    else
                    {
                        AlIns.Nota = (int)drInscripciones["nota"];
                    }
                    Inscripciones.Add(AlIns);
                }
                drInscripciones.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de Inscripciones", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
            return Inscripciones;
        }


        //public int GetOneByDesc(string descripcion)

        //{
        //    int Id;
        //    try
        //    {
        //        this.OpenConnection();

        //        SqlCommand cmdMateria = new SqlCommand("select id_materia from MATERIAS where desc_materia = @descripcion ", sqlConn);
        //        cmdMateria.Parameters.Add("@descripcion", SqlDbType.VarChar, 50).Value = descripcion;

        //        Id = Convert.ToInt32(cmdMateria.ExecuteScalar());




        //    }
        //    catch (Exception Ex)
        //    {
        //        Exception ExcepcionManejada =
        //            new Exception("Erro al recuperar lista de Materias", Ex);

        //        throw ExcepcionManejada;
        //    }
        //    finally
        //    {
        //        this.CloseConnection();
        //    }

        //    return Id;

        //}

        public List<AlumnoInscripcion> GetInscripcionesByAlumno(Usuario usuario)
        {
            List<AlumnoInscripcion> Inscripciones = new List<AlumnoInscripcion>();
            try
            {
                OpenConnection();
                SqlCommand cmdAlumnoInscripcion = new SqlCommand("select * from alumno_inscripciones where id_alumno = @idAlumno", sqlConn);
                cmdAlumnoInscripcion.Parameters.Add("@idAlumno", SqlDbType.Int).Value = usuario.Persona.ID;
                SqlDataReader drInscripciones = cmdAlumnoInscripcion.ExecuteReader();
                while (drInscripciones.Read())
                {
                    AlumnoInscripcion ins = new AlumnoInscripcion();
                    ins.Alumno = new PersonasAdapter().GetOne((int)drInscripciones["id_alumno"]);
                    ins.ID = (int)drInscripciones["id_inscripcion"];

                    ins.Curso = new CursoAdapter().GetOne((int)drInscripciones["id_curso"]);
                    ins.Condicion = (string)drInscripciones["condicion"];
                    // Valido que la nota no sea null
                    if (String.IsNullOrEmpty(drInscripciones["nota"].ToString()))
                    {
                        ins.Nota = 0;
                    }
                    else
                    {
                        ins.Nota = (int)drInscripciones["nota"];
                    }
                    Inscripciones.Add(ins);
                }
                drInscripciones.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar la lista de Alumnos Inscriptos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
            return Inscripciones;
        }

        public List<AlumnoInscripcion> GetInscripcionesByDocente(Usuario usuario)
        {
            List<AlumnoInscripcion> Inscripciones = new List<AlumnoInscripcion>();
            try
            {
                OpenConnection();
                SqlCommand cmdDocenteInscripcion = new SqlCommand("select * from docentes_cursos dc inner join" +
                    "alumnos_inscripciones ai on ai.id_curso = dc.id_curso where dc.id_docente = @idDocente", sqlConn);
                cmdDocenteInscripcion.Parameters.Add("@idDocente", SqlDbType.Int).Value = usuario.Persona.ID;
                SqlDataReader drIncripciones = cmdDocenteInscripcion.ExecuteReader();

                while (drIncripciones.Read())
                {
                    AlumnoInscripcion ins = new AlumnoInscripcion();
                    ins.Alumno = new PersonasAdapter().GetOne((int)drIncripciones["id_alumno"]);
                    ins.ID = (int)drIncripciones["id_inscripcion"];

                    ins.Curso = new CursoAdapter().GetOne((int)drIncripciones["id_curso"]);
                    ins.Condicion = (string)drIncripciones["condicion"];
                    // validar que la notas no sean null
                    if (String.IsNullOrEmpty(drIncripciones["nota"].ToString()))
                    {
                        ins.Nota = 0;
                    }
                    else
                    {
                        ins.Nota = (int)drIncripciones["nota"];
                    }
                    Inscripciones.Add(ins);
                }
                drIncripciones.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar la lista de Inscripciones", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
            return Inscripciones;
        }

        public Business.Entities.AlumnoInscripcion GetOne(int ID)
        {
            AlumnoInscripcion ins = new AlumnoInscripcion();
            try
            {
                this.OpenConnection();

                SqlCommand cmdInscripcion = new SqlCommand("select * from alumnos_inscripciones where id_inscripcion = @id", sqlConn);
                cmdInscripcion.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drInscripcion = cmdInscripcion.ExecuteReader();

                if (drInscripcion.Read())
                {
                    ins.ID = (int)drInscripcion["id_inscripcion"];
                    ins.Alumno = new PersonasAdapter().GetOne((int)drInscripcion["id_alumno"]);
                    ins.Curso = new CursoAdapter().GetOne((int)drInscripcion["id_curso"]);

                    /* ARREGLADO ARRIBA
                    ins.IDAlumno = (int)drInscripcion["id_alumno"];
                    ins.IDCurso = (int)drInscripcion["id_curso"];
                    */
                    ins.Condicion = (string)drInscripcion["condicion"];
                    // validar que no sea nula
                    if (String.IsNullOrEmpty(drInscripcion["nota"].ToString()))
                    {
                        ins.Nota = 0;
                    }
                    else
                    {
                        ins.Nota = (int)drInscripcion["nota"];
                    }                   
                }
                drInscripcion.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de Inscripciones", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return ins;
        }

        public List<AlumnoInscripcion> GetAllByCurso(int ID)
        {
            List<AlumnoInscripcion> Inscripciones = new List<AlumnoInscripcion>();
            try
            {
                OpenConnection();
                SqlCommand cmdInscripcionesCurso = new SqlCommand("select * from alumnos_inscripciones where id_curso = @idcurso", sqlConn);
                cmdInscripcionesCurso.Parameters.Add("@idcurso", SqlDbType.Int).Value = ID;
                SqlDataReader drIncripciones = cmdInscripcionesCurso.ExecuteReader();

                while (drIncripciones.Read())
                {
                    AlumnoInscripcion ins = new AlumnoInscripcion();
                    ins.Alumno = new PersonasAdapter().GetOne((int)drIncripciones["id_alumno"]);
                    ins.ID = (int)drIncripciones["id_inscripcion"];

                    ins.Curso = new CursoAdapter().GetOne((int)drIncripciones["id_curso"]);
                    ins.Condicion = (string)drIncripciones["condicion"];
                    // validar que la notas no sean null
                    if (String.IsNullOrEmpty(drIncripciones["nota"].ToString()))
                    {
                        ins.Nota = 0;
                    }
                    else
                    {
                        ins.Nota = (int)drIncripciones["nota"];
                    }
                    Inscripciones.Add(ins);
                }
                drIncripciones.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar la lista de Inscripciones", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
            return Inscripciones;
        }

        public bool GetOne(AlumnoInscripcion inscrip)
        {
            AlumnoInscripcion ins = new AlumnoInscripcion();

            try
            {
                OpenConnection();
                SqlCommand cmdInscripciones = new SqlCommand("select * from alumnos_inscripciones where id_alumno = @idAlumno and id_curso = @idCurso", sqlConn);
                cmdInscripciones.Parameters.Add("@idAlumno", SqlDbType.Int).Value = inscrip.Alumno.ID;
                cmdInscripciones.Parameters.Add("@idCurso", SqlDbType.Int).Value = inscrip.Curso.ID;
                SqlDataReader drInscripciones = cmdInscripciones.ExecuteReader();

                if (drInscripciones.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al validad la Inscripción", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete =
                    new SqlCommand("delete alumnos_inscripciones where id_inscripcion= @id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al eliminar inscripcion", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

        }

        public void Delete(AlumnoInscripcion alumnoInscripcion)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete from alumnos_inscripciones where id_inscripcion=@idInscripcion", sqlConn);
                cmdDelete.Parameters.Add("@idInscripcion", SqlDbType.Int).Value = alumnoInscripcion.ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar la inscripcion", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        protected void Update(AlumnoInscripcion inscripcion)
        {
            try
            {
                this.OpenConnection();
                //CAPAS QUE HAY ERROR ACA NO ESTA REVISADO
                SqlCommand cmdSave = new SqlCommand(
                    "UPDATE alumnos_inscripciones SET id_alumno = @id_alumno, id_curso = @id_curso, condicion = @condicion, nota = @nota " +
                    "WHERE id_inscripcion = @id", sqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = inscripcion.ID;
                cmdSave.Parameters.Add("@id_alumno", SqlDbType.Int).Value = inscripcion.IDAlumno;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = inscripcion.IDCurso;
                cmdSave.Parameters.Add("@condicion", SqlDbType.VarChar,50).Value = inscripcion.Condicion;
                cmdSave.Parameters.Add("@nota", SqlDbType.Int).Value = inscripcion.Nota;
                cmdSave.ExecuteNonQuery();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al modificar datos de inscripciones", Ex);
                throw ExcepcionManejada;
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
                // PUEDE HABER ERRORES ACA , HAY QUE REVISAR
                SqlCommand cmdSave = new SqlCommand(
                    "insert into alumnos_inscripciones(id_alumno,id_curso,condicion,nota)" +
                    "values (@id_alumno,@id_curso,@condicion,@nota)" +
                    "select @@identity",
                    sqlConn);


                cmdSave.Parameters.Add("@id_alumno", SqlDbType.Int).Value = inscripcion.IDAlumno;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = inscripcion.IDCurso;
                cmdSave.Parameters.Add("@condicion", SqlDbType.VarChar,50).Value = inscripcion.Condicion;
                cmdSave.Parameters.Add("@nota", SqlDbType.Int).Value = inscripcion.Nota;
                //inscripcion.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
                //Asi se obtiene el id desde la base de datos
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al crear inscripcion", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(AlumnoInscripcion inscripcion)
        {
            if (inscripcion.State == BusinessEntity.States.Deleted)
            {
                this.Delete(inscripcion.ID);
            }
            else if (inscripcion.State == BusinessEntity.States.New)
            {
                this.Insert(inscripcion);
            }
            else if (inscripcion.State == BusinessEntity.States.Modified)
            {
                this.Update(inscripcion);
            }
            inscripcion.State = BusinessEntity.States.Unmodified;
        }
    }
}

