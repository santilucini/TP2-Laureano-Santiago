using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class DocenteCursoAdapter : Adapter
    {
        public List<DocenteCurso> GetAll()
        {
            List<DocenteCurso> docenteCursos = new List<DocenteCurso>();

            try
            {
                this.OpenConnection();

                SqlCommand cmdDocenteCursos = new SqlCommand("select * from docentes_cursos", sqlConn);

                SqlDataReader drDocenteCursos = cmdDocenteCursos.ExecuteReader();

                while (drDocenteCursos.Read())
                {
                    DocenteCurso doc = new DocenteCurso();

                    doc.ID = (int)drDocenteCursos["id_dictado"];

                    doc.Curso = new CursoAdapter().GetOne((int)drDocenteCursos["id_curso"]);
                    doc.Docente = new PersonasAdapter().GetOne((int)drDocenteCursos["id_docente"]);

                    /* CORREGIDO ARRIBA
                    doc.IDCurso = (int)drDocenteCursos["id_curso"];
                    doc.IDDocente = (int)drDocenteCursos["id_docente"];
                    */

                    doc.Cargo = (DocenteCurso.TiposCargos)(int)drDocenteCursos["cargo"];
                   

                    docenteCursos.Add(doc);
                }

                drDocenteCursos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Erro al recuperar lista de Docente-Curso", Ex);

                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return docenteCursos;
        }

        public List<Persona> GetAll(Curso curso)
        {
            List<Persona> DocentesCurso = new List<Persona>();
            try
            {
                OpenConnection();
                SqlCommand cmdDocenteCursos = new SqlCommand("select id_docente from docentes_curso where id_curso = @idCurso", sqlConn);

                SqlDataReader drDocenteCursos = cmdDocenteCursos.ExecuteReader();

                while (drDocenteCursos.Read())
                {
                    Persona docente = new Persona();
                    docente = new PersonasAdapter().GetOne((int)drDocenteCursos["id_docente"]);
                    DocentesCurso.Add(docente);
                }
                drDocenteCursos.Close();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de Cursos-Docente", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
            return DocentesCurso;
        }

        public List<DocenteCurso> GetAllByCurso(int ID)
        {
            List<DocenteCurso> DocentesCurso = new List<DocenteCurso>();
            try
            {
                OpenConnection();
                SqlCommand cmdDocenteCursos = new SqlCommand("select id_docente from docentes_curso where id_curso = @idCurso", sqlConn);
                cmdDocenteCursos.Parameters.Add("@idcurso", SqlDbType.Int).Value = ID;
                SqlDataReader drDocenteCursos = cmdDocenteCursos.ExecuteReader();

                while (drDocenteCursos.Read())
                {
                    DocenteCurso docenteCurso = new DocenteCurso();
                    docenteCurso.Docente = new PersonasAdapter().GetOne((int)drDocenteCursos["id_docente"]);
                    docenteCurso.Curso = new CursoAdapter().GetOne((int)drDocenteCursos["id_curso"]);
                    docenteCurso.ID = (int)drDocenteCursos["id_dictado"];
                    doc.Cargo = (DocenteCurso.TiposCargos)(int)drDocenteCursos["cargo"];
                    DocentesCurso.Add(docenteCurso);
                }
                drDocenteCursos.Close();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de Cursos-Docente", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
            return DocentesCurso;

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


        public Business.Entities.DocenteCurso GetOne(int ID)
        {
            DocenteCurso doc = new DocenteCurso();
            try
            {
                this.OpenConnection();

                SqlCommand cmdDocenteCursos = new SqlCommand("select * from docentes_cursos where id_dictado = @id", sqlConn);
                cmdDocenteCursos.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drDocenteCursos = cmdDocenteCursos.ExecuteReader();

                if (drDocenteCursos.Read())
                {
                    doc.ID = (int)drDocenteCursos["id_dictado"];
                    doc.Curso = new CursoAdapter().GetOne((int)drDocenteCursos["id_curso"]);
                    doc.Docente = new PersonasAdapter().GetOne((int)drDocenteCursos["id_persona"]);
                    /* CORREGIDO ARRIBA
                    doc.IDCurso = (int)drDocenteCursos["id_curso"];
                    doc.IDDocente = (int)drDocenteCursos["id_docente"];
                    */
                    doc.Cargo = (DocenteCurso.TiposCargos)(int)drDocenteCursos["cargo"];
                }
                drDocenteCursos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de Cursos-Docente", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return doc;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete =
                    new SqlCommand("delete docentes_cursos where id_dictado = @id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al eliminar el Docente-Curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

        }

        protected void Update(DocenteCurso docenteCursos)
        {
            try
            {
                this.OpenConnection();
                //CAPAS QUE HAY ERROR ACA NO ESTA REVISADO
                SqlCommand cmdSave = new SqlCommand(
                    "UPDATE docentes_cursos SET id_curso = @id_curso, id_docente = @id_docente, cargo = @cargo " +
                    "WHERE id_dictado = @id", sqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = docenteCursos.ID;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = docenteCursos.IDCurso;
                cmdSave.Parameters.Add("@id_docente", SqlDbType.Int).Value = docenteCursos.IDDocente;
                cmdSave.Parameters.Add("@cargo", SqlDbType.Int).Value = docenteCursos.Cargo;
                cmdSave.ExecuteNonQuery();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al modificar datos del Docente-Curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(DocenteCurso docenteCursos)
        {
            try
            {
                this.OpenConnection();
                // PUEDE HABER ERRORES ACA , HAY QUE REVISAR
                SqlCommand cmdSave = new SqlCommand(
                    "insert into docentes_cursos(id_curso,id_docente,cargo)" +
                    "values (@id_curso,@id_docente,@cargo)" +
                    "select @@identity",
                    sqlConn);


                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = docenteCursos.IDCurso;
                cmdSave.Parameters.Add("@id_docente", SqlDbType.Int).Value = docenteCursos.IDDocente;
                cmdSave.Parameters.Add("@cargo", SqlDbType.Int).Value = docenteCursos.Cargo;
                docenteCursos.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
                //Asi se obtiene el id desde la base de datos
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al crear dictado", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(DocenteCurso docenteCursos)
        {
            if (docenteCursos.State == BusinessEntity.States.Deleted)
            {
                this.Delete(docenteCursos.ID);
            }
            else if (docenteCursos.State == BusinessEntity.States.New)
            {
                this.Insert(docenteCursos);
            }
            else if (docenteCursos.State == BusinessEntity.States.Modified)
            {
                this.Update(docenteCursos);
            }
            docenteCursos.State = BusinessEntity.States.Unmodified;
        }
    }
}
