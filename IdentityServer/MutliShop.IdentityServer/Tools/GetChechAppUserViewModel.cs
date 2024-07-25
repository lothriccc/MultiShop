using System.Text;

namespace MutliShop.IdentityServer.Tools
{
	public class GetChechAppUserViewModel
	{
        public string Id { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public bool IsExist { get; set; }
    }
}
