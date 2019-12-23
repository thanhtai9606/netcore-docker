using acb_app.Models;
using acb_app.Repositories.Services;
using BecamexIDC.Pattern.EF.DataContext;
using BecamexIDC.Pattern.EF.Factory;
using BecamexIDC.Pattern.EF.Repositories;
using BecamexIDC.Pattern.EF.UnitOfWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System;
using acb_app.Helpers;

namespace acb_app
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration _configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var identitySettingSection = _configuration.GetSection("AppIdentitySettings");
            var appSettingsSection = _configuration.GetSection("AppSettings");
            services.AddDbContext<ACBSystemContext>(options => options.UseMySql(_configuration.GetConnectionString("MySqlConnection")));
            services.AddDbContext<AuthDbContext>(options => options.UseMySql(_configuration.GetConnectionString("MySqlAuthConnection")));

            services.AddIdentity<IdentityUser, IdentityRole>()
                    .AddDefaultTokenProviders()
                    .AddEntityFrameworkStores<AuthDbContext>();
            services.AddScoped<IDataContextAsync, ACBSystemContext>();

            // configure strongly typed settings objects      
            services.Configure<AppIdentitySettings>(identitySettingSection);
            services.Configure<AppSettings>(appSettingsSection);
            services.AddScoped<IUnitOfWorkAsync, UnitOfWork>();
        #region  Repository Generic
            
            services.AddScoped<IRepositoryAsync<Address>, Repository<Address>>();    
            services.AddScoped<IRepositoryAsync<AddressType>, Repository<AddressType>>();
            services.AddScoped<IRepositoryAsync<BusinessEntity>, Repository<BusinessEntity>>();  
            services.AddScoped<IRepositoryAsync<BusinessEntityAddress>, Repository<BusinessEntityAddress>>();                 
            services.AddScoped<IRepositoryAsync<BusinessEntityContact>, Repository<BusinessEntityContact>>();   
            services.AddScoped<IRepositoryAsync<BusinessEntityPhone>, Repository<BusinessEntityPhone>>();   
            services.AddScoped<IRepositoryAsync<ContactType>, Repository<ContactType>>();
            services.AddScoped<IRepositoryAsync<District>, Repository<District>>();            
            services.AddScoped<IRepositoryAsync<Employee>, Repository<Employee>>();
            services.AddScoped<IRepositoryAsync<Person>, Repository<Person>>();
            services.AddScoped<IRepositoryAsync<Phone>, Repository<Phone>>();
            services.AddScoped<IRepositoryAsync<PhoneType>, Repository<PhoneType>>();
            services.AddScoped<IRepositoryAsync<Product>, Repository<Product>>();
            services.AddScoped<IRepositoryAsync<ProductCategory>, Repository<ProductCategory>>();
            services.AddScoped<IRepositoryAsync<ProductInventory>, Repository<ProductInventory>>();
            services.AddScoped<IRepositoryAsync<ProductListPriceHistory>, Repository<ProductListPriceHistory>>();
            services.AddScoped<IRepositoryAsync<ProductPhoto>, Repository<ProductPhoto>>();
            services.AddScoped<IRepositoryAsync<ProductProductPhoto>, Repository<ProductProductPhoto>>();
            services.AddScoped<IRepositoryAsync<ProductSubCategory>, Repository<ProductSubCategory>>();
            services.AddScoped<IRepositoryAsync<Province>, Repository<Province>>();
            services.AddScoped<IRepositoryAsync<PurchaseOrderHeader>, Repository<PurchaseOrderHeader>>();
            services.AddScoped<IRepositoryAsync<PurchaseOrderDetail>, Repository<PurchaseOrderDetail>>();
            services.AddScoped<IRepositoryAsync<SalesOrderDetail>, Repository<SalesOrderDetail>>();
            services.AddScoped<IRepositoryAsync<SaleOrderHeader>, Repository<SaleOrderHeader>>();
            services.AddScoped<IRepositoryAsync<TransactionHistory>, Repository<TransactionHistory>>();
            services.AddScoped<IRepositoryAsync<UnitMeasure>, Repository<UnitMeasure>>();
            services.AddScoped<IRepositoryAsync<Vendor>, Repository<Vendor>>();
            services.AddScoped<IRepositoryAsync<Ward>, Repository<Ward>>();
        #endregion
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IAddressTypeService, AddressTypeService>();            
            services.AddScoped<IBusinessEntityService, BusinessEntityService>();
            services.AddScoped<IBusinessEntityAddressService, BusinessEntityAddressService>();
            services.AddScoped<IBusinessEntityContactService, BusinessEntityContactService>();
            services.AddScoped<IBusinessEntityPhoneService, BusinessEntityPhoneService>();
            services.AddScoped<IContactTypeService, ContactTypeService>();
            services.AddScoped<IDistrictService, DistrictService>();            
            services.AddScoped<IEmployeeService, EmployeeService>();            
            services.AddScoped<IPersonService, PersonService>();            
            services.AddScoped<IPhoneService, PhoneService>();
            services.AddScoped<IPhoneTypeService, PhoneTypeService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductCategoryService, ProductCategoryService>();
            services.AddScoped<IProductInventoryService, ProductInventoryService>();
            services.AddScoped<IProductListPriceHistoryService, ProductListPriceHistoryService>();
            services.AddScoped<IProductPhotoService, ProductPhotoService>();
            services.AddScoped<IProductSubCategoryService, ProductSubCategoryService>();
            services.AddScoped<IProvinceService, ProvinceService>();
            services.AddScoped<IPurchaseOrderHeaderService, PurchaseOrderHeaderService>();
            services.AddScoped<IPurchaseOrderDetailService, PurchaseOrderDetailService>();
            services.AddScoped<ISaleOrderHeaderService, SaleOrderHeaderService>();
            services.AddScoped<ISaleOrderDetailService, SaleOrderDetailService>();
            services.AddScoped<ITransactionHistoryService, TransactionHistoryService>();
            services.AddScoped<IUnitMeasureService, UnitMeasureService>();
            services.AddScoped<IVendorService, VendorService>();
            services.AddScoped<IWardService, WardService>();

            var identitySettings = identitySettingSection.Get<AppIdentitySettings>();

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var passwordSettings = appSettingsSection.Get<PasswordSettings>();
            var lockoutSettings = appSettingsSection.Get<LockoutSettings>();
            var userSettings = appSettingsSection.Get<UserSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Token);

            services.Configure<IdentityOptions>(options =>
                        {
                            // Password settings
                            options.Password.RequireDigit = passwordSettings.RequireDigit;
                            options.Password.RequiredLength = passwordSettings.RequiredLength;
                            options.Password.RequireNonAlphanumeric = passwordSettings.RequireNonAlphanumeric;
                            options.Password.RequireUppercase = passwordSettings.RequireUppercase;
                            options.Password.RequireLowercase = passwordSettings.RequireLowercase;
                            options.Password.RequiredUniqueChars = passwordSettings.RequiredUniqueChars;

                            // Lockout settings
                            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(lockoutSettings.DefaultLockoutTimeSpanInMins);
                            options.Lockout.MaxFailedAccessAttempts = lockoutSettings.MaxFailedAccessAttempts;
                            options.Lockout.AllowedForNewUsers = lockoutSettings.AllowedForNewUsers;

                            // User settings
                            options.User.RequireUniqueEmail = userSettings.RequireUniqueEmail;
                        });
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
