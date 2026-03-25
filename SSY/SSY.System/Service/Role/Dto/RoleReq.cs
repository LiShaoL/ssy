namespace SSY.System;

public class AddRoleReq
{
    [Required(ErrorMessage = "名字不为空")]
    public string Name { get; set; }
    /// <summary>
    /// 备注 
    ///</summary>
    public string Remark { get; set; }
    /// <summary>
    /// 状态 
    ///</summary>
    public int Status { get; set; }
}
public class UpdateRoleReq : AddRoleReq
{
    public long Id { get; set; }
}
public class RoleId
{
    public long Id { get; set; }
}
public class AssignPermissionsReq : RoleId
{
    public List<long> MenuIds { get; set; }
}
public class GetRoleListReq : BasePageInput
{
    /// <summary>
    /// 名称 
    ///</summary>
    public string Name { get; set; }
}
