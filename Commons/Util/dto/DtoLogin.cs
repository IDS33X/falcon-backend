namespace Util.dto
{
    public class DtoLogin
    {
        public DtoLogin(string Code,string Password){
            this.Code = Code;
            this.Password = Password;
        }

        public DtoLogin(){
            
        }

        public string Code { get; set; }
        public string Password { get; set; }
    }
}