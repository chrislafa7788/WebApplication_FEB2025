namespace WebApplication_FEB2025.Services
{
    public interface IPostService
    {
        public Task<IEnumerable<DTOs.PostDto>> Get();
        //List es una clase
        //List es para manipular informacion.
        //IEnumerable tiene lo necesario para recorrer. es mas rapido y eficiente q dar una Lista.
        //Una lista implementa IEnumerable. y encima es de solo lectura.

    }
}
