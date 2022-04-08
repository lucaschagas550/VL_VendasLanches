namespace VL_VendasLanches.Models
{
    public class FileManagerModel
    {
        //Acesso a metodos e propriedades para tratar os arquivos
        public FileInfo[] Files { get; set; } 
        //Permite enviar o arquivos e metodos do arquivo
        public IFormFile IFormFile { get; set; }
        public List<IFormFile> IFormFiles { get; set; }
        public string PathImagesProduto { get; set; }
    }
}