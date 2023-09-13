using Microsoft.AspNetCore.Identity;
using Moq;
using ProductCatalog.Infra.Data.Identity;

namespace ProductCatalog.Infra.Data.Tests.Identity
{
    public class SeedUserRoleInitialTest
    {
        [Fact(DisplayName = "SeedUsers - Return User When Created")]
        public void SeedUserRoleInitial_SeedUsers_UserDoesNotExistShouldToCreateUser()
        {
            var userManager = new Mock<UserManager<ApplicationUser>>(
                new Mock<IUserStore<ApplicationUser>>().Object,
                null, null, null, null, null, null, null, null);

            var roleManager = new Mock<RoleManager<IdentityRole>>(
                new Mock<IRoleStore<IdentityRole>>().Object, null, null, null, null);

            userManager.SetupSequence(m => m.CreateAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Success)
                .ReturnsAsync(IdentityResult.Failed());

            userManager.Setup(m => m.FindByEmailAsync("usuario@localhost")).ReturnsAsync((ApplicationUser)null);
            userManager.Setup(m => m.AddToRoleAsync(It.IsAny<ApplicationUser>(), "User"))
                .ReturnsAsync(IdentityResult.Success);

            var seedUserRoleInitial = new SeedUserRoleInitial(roleManager.Object, userManager.Object);

            seedUserRoleInitial.SeedUsers();

            userManager.Verify(m => m.FindByEmailAsync("usuario@localhost"), Times.Once);
            userManager.Verify(m => m.CreateAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()), Times.Exactly(2));
            userManager.Verify(m => m.AddToRoleAsync(It.IsAny<ApplicationUser>(), "User"), Times.Once);
        }

        [Fact(DisplayName = "SeedUsers - Not Return User When Fails Created")]
        public void SeedUserRoleInitial_SeedUsers_UserDoesNotExistShouldFailsToCreateUser()
        {
            var userManager = new Mock<UserManager<ApplicationUser>>(
                new Mock<IUserStore<ApplicationUser>>().Object,
                null, null, null, null, null, null, null, null);

            var roleManager = new Mock<RoleManager<IdentityRole>>(
                new Mock<IRoleStore<IdentityRole>>().Object, null, null, null, null);

            userManager.SetupSequence(m => m.CreateAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Failed())
                .ReturnsAsync(IdentityResult.Failed());

            userManager.Setup(m => m.FindByEmailAsync("usuario@localhost")).ReturnsAsync((ApplicationUser)null);
            userManager.Setup(m => m.AddToRoleAsync(It.IsAny<ApplicationUser>(), "User"))
                .ReturnsAsync(IdentityResult.Success);

            var seedUserRoleInitial = new SeedUserRoleInitial(roleManager.Object, userManager.Object);

            seedUserRoleInitial.SeedUsers();

            userManager.Verify(m => m.FindByEmailAsync("usuario@localhost"), Times.Once);
            userManager.Verify(m => m.CreateAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()), Times.Exactly(2));
            userManager.Verify(m => m.AddToRoleAsync(It.IsAny<ApplicationUser>(), "User"), Times.Never);
        }


        [Fact(DisplayName = "SeedRoles - Return User When Created Roles")]
        public void SeedUserRoleInitial_SeedRoles_RolesDoNotExistShouldCreatesRoles()
        {
        
            var userManager = new Mock<UserManager<ApplicationUser>>(
                new Mock<IUserStore<ApplicationUser>>().Object,
                null, null, null, null, null, null, null, null);

            var roleManager = new Mock<RoleManager<IdentityRole>>(
                new Mock<IRoleStore<IdentityRole>>().Object, null, null, null, null);

            roleManager.Setup(r => r.RoleExistsAsync("User")).ReturnsAsync(false);
            roleManager.Setup(r => r.RoleExistsAsync("Admin")).ReturnsAsync(false);

            roleManager.Setup(r => r.CreateAsync(It.IsAny<IdentityRole>())).ReturnsAsync(IdentityResult.Success);

            var seedUserRoleInitial = new SeedUserRoleInitial(roleManager.Object, userManager.Object);

            seedUserRoleInitial.SeedRoles();

            roleManager.Verify(r => r.RoleExistsAsync("User"), Times.Once);
            roleManager.Verify(r => r.RoleExistsAsync("Admin"), Times.Once);

            roleManager.Verify(r => r.CreateAsync(It.Is<IdentityRole>(role => role.Name == "User")), Times.Once);
            roleManager.Verify(r => r.CreateAsync(It.Is<IdentityRole>(role => role.Name == "Admin")), Times.Once);
        }

        [Fact(DisplayName = "SeedRoles - Return User When Fails Created Roles")]
        public void SeedUserRoleInitia_SeedRoles_RolesDoNotExistShouldFailsToCreateRoles()
        {
            var userManager = new Mock<UserManager<ApplicationUser>>(
                new Mock<IUserStore<ApplicationUser>>().Object,
                null, null, null, null, null, null, null, null);

            var roleManager = new Mock<RoleManager<IdentityRole>>(
                new Mock<IRoleStore<IdentityRole>>().Object, null, null, null, null);

            roleManager.Setup(r => r.RoleExistsAsync("User")).ReturnsAsync(false);
            roleManager.Setup(r => r.RoleExistsAsync("Admin")).ReturnsAsync(false);

            roleManager.Setup(r => r.CreateAsync(It.Is<IdentityRole>(role => role.Name == "User")))
                .ReturnsAsync(IdentityResult.Failed());

            roleManager.Setup(r => r.CreateAsync(It.Is<IdentityRole>(role => role.Name == "Admin")))
                .ReturnsAsync(IdentityResult.Success);

            var seedUserRoleInitial = new SeedUserRoleInitial(roleManager.Object, userManager.Object);

            seedUserRoleInitial.SeedRoles();

            roleManager.Verify(r => r.RoleExistsAsync("User"), Times.Once);
            roleManager.Verify(r => r.RoleExistsAsync("Admin"), Times.Once);

            roleManager.Verify(r => r.CreateAsync(It.Is<IdentityRole>(role => role.Name == "User")), Times.Once);
            roleManager.Verify(r => r.CreateAsync(It.Is<IdentityRole>(role => role.Name == "Admin")), Times.Once);
        }
    }
}
