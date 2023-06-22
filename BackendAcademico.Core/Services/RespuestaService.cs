namespace BackendAcademico.Core.Services
{
    public class RespuestaService<T>
    {
        public RespuestaService() 
        {
            Status = 200;
        }

        public int Status { get; set; }
        public T? Objeto { get; set; }
        public string Error { get; set; }   
        public bool Exito { get; set; }

        public void AgregarBadRequest(string mensaje)
        {
            Status = 400;
            Error = mensaje;
        }

        public void AgregarInternalServerError(string mensaje)
        {
            Status = 500;
            Error = mensaje;
        }

    }
}