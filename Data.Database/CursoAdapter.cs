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
    public class CursoAdapter : Adapter
    {
        public List<Curso> GetAll()
        {
            List<Curso> cursos = new List<Curso>();

            try
            {
                this.OpenConnection();

                SqlCommand cmdCursos = new SqlCommand("select * from cursos", sqlConn);

                SqlDataReader drCursos = cmdCursos.ExecuteReader();

                while (drCursos.Read())
                {
                    Curso cur = new Curso();

                    cur.ID = (int)drCursos["id_curso"];
                    cur.AnioCalendario = (int)drCursos["anio_calendario"];
                    cur.Cupo = (int)drCursos["cupo"];

                    cur.Comision = new ComisionAdapter().GetOne((int)drCursos["id_comision"]);
                    cur.Materia = new MateriaAdapter().GetOne((int)drCursos["id_materia"]);
                   
                    /* MAL HECHO CORREGIDO  ARRIBA
                    cur.IDMateria = (int)drCursos["id_materia"];
                    cur.IDComision = (int)drCursos["id_comision"];
                    */

                    cursos.Add(cur);
                }

                drCursos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al recuperar lista de Cursos", Ex);

                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return cursos;
        }

        /***** COMENTO POR SI EN EL FUTURO HAY QUE UTILIZAR ALGUNA BUSQUEDA POR UN CAMPO ESPECIFICO*****/
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

    /*************** HASTA ACA ****************/
        public Business.Entities.Curso GetOne(int ID)
        {
            Curso cur = new Curso();
            try
            {
                this.OpenConnection();

                SqlCommand cmdCursos = new SqlCommand("select * from cursos where id_curso = @id", sqlConn);
                cmdCursos.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drCursos = cmdCursos.ExecuteReader();

                if (drCursos.Read())
                {
                    cur.ID = (int)drCursos["id_curso"];
                    cur.AnioCalendario = (int)drCursos["anio_calendario"];
                    cur.Cupo = (int)drCursos["cupo"];

                    cur.Comision = new ComisionAdapter().GetOne((int)drCursos["id_comision"]);
                    cur.Materia = new MateriaAdapter().GetOne((int)drCursos["id_materia"]);
                     
                    /* CORREGIDO ARRIBA
                    cur.IDMateria = (int)drCursos["id_materia"];
                    cur.IDComision = (int)drCursos["id_comision"];
                    */
                }
                drCursos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de Cursos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return cur;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete =
                    new SqlCommand("delete cursos where id_curso = @id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al eliminar curso", Ex);
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
                SqlCommand cmdSave = new SqlCommand(
                    "UPDATE cursos SET id_materia = @id_materia, id_comision = @id_comision, anio_calendario = @anio_calendario, cupo = @cupo " +
                    "WHERE id_curso = @id", sqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = curso.ID;
                cmdSave.Parameters.Add("@id_materia", SqlDbType.Int).Value = curso.IDMateria;
                cmdSave.Parameters.Add("@id_comision", SqlDbType.Int).Value = curso.IDComision;
                cmdSave.Parameters.Add("@anio_calendario", SqlDbType.Int).Value = curso.AnioCalendario;
                cmdSave.Parameters.Add("@cupo", SqlDbType.Int).Value = curso.Cupo;
                cmdSave.ExecuteNonQuery();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al modificar datos del curso", Ex);
                throw ExcepcionManejada;
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
                // PUEDE HABER ERRORES ACA , HAY QUE REVISAR
                SqlCommand cmdSave = new SqlCommand(
                    "insert into cursos(id_materia,id_comision,anio_calendario,cupo)" +
                    "values (@id_materia,@id_comision,@anio_calendario,@cupo)" +
                    "select @@identity",
                    sqlConn);

                cmdSave.Parameters.Add("@id_materia", SqlDbType.Int).Value = curso.IDMateria;
                cmdSave.Parameters.Add("@id_comision", SqlDbType.Int).Value = curso.IDComision;
                cmdSave.Parameters.Add("@anio_calendario", SqlDbType.Int).Value = curso.AnioCalendario;
                cmdSave.Parameters.Add("@cupo", SqlDbType.Int).Value = curso.Cupo;
                //curso.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
                //Asi se obtiene el id desde la base de datos
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al crear curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Curso curso)
        {
            if (curso.State == BusinessEntity.States.Deleted)
            {
                this.Delete(curso.ID);
            }
            else if (curso.State == BusinessEntity.States.New)
            {
                this.Insert(curso);
            }
            else if (curso.State == BusinessEntity.States.Modified)
            {
                this.Update(curso);
            }
            curso.State = BusinessEntity.States.Unmodified;
        }

        public void ModificarCupoCurso(Curso curso)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE cursos SET cupo=@cupo-1 WHERE id_curso=@idCurso", sqlConn);
                cmdSave.Parameters.Add("@idCurso", SqlDbType.Int).Value = curso.ID;
                cmdSave.Parameters.Add("@cupo", SqlDbType.Int).Value = curso.Cupo;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar los Datos del Curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}