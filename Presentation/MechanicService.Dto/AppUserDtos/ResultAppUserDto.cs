namespace MechanicService.Dto.AppUserDtos
{
    public class ResultAppUserDto
    {
        public ResultDto Result { get; set; }
    }

    public class ResultDto
    {
        public int AppUserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int AppRoleID { get; set; }
    }
}
