using System.Collections.Generic;
using System.Linq;
using RepoDb;
using RepoDb.DbSettings;
using RepoDb.Enumerations;
using RepoDb.StatementBuilders;
using RepoDb.DbHelpers;
using Microsoft.Data.SqlClient;
using Metaphor_Backend;
using Metaphor_Backend.Models;
using Microsoft.Extensions.Configuration;
using System.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
// using Microsoft.Extensions.Configuration;

namespace Metaphor_Backend.Repositories // Adjust the namespace as per your project structure
{

    public class UserRepository : BaseRepository<User, SqlConnection>
    {
        Setting sett = new Setting();

        public UserRepository(Setting sett) : base(sett.ConnectionStrings)
        {
            this.sett = sett;
            DbSettingMapper.Add<SqlConnection>(new SqlServerDbSetting(), true);
            DbHelperMapper.Add<SqlConnection>(new SqlServerDbHelper(), true);
            StatementBuilderMapper.Add<SqlConnection>(new SqlServerStatementBuilder(new SqlServerDbSetting()), true);
        }

        public void InsertUser(User user)
        {
            using (var connection = new SqlConnection(sett.ConnectionStrings))
            {
                connection.Insert(user);
            }
        }

        public void UpdateUser(User user)
        {
            using (var connection = new SqlConnection(sett.ConnectionStrings))
            {
                connection.Update(user);
            }
        }

        public int DeleteUser(User user)
        {
            using (var connection = new SqlConnection(sett.ConnectionStrings))
            {
                return connection.Delete<User>(user);
            }
        }

        public List<User> GetUsers()
        {
            var users = new List<User>();
            using (var connection = new SqlConnection(sett.ConnectionStrings))
            {

                users = connection.QueryAll<User>().ToList();
            }
            return users;
        }

        public User GetUser(int id)
        {
            using (var connection = new SqlConnection(sett.ConnectionStrings))
            {
#pragma warning disable CS8603 // Possible null reference return.
                return connection.Query<User>(id).FirstOrDefault();
#pragma warning restore CS8603 // Possible null reference return.
            }
        }
        public UserCredentials GetUserByEmail(string username)
        {
            using (var connection = new SqlConnection(sett.ConnectionStrings))
            {
                // Assuming there is an Email property in the User model
#pragma warning disable CS8603 // Possible null reference return.
                return connection.Query<UserCredentials>(e => e.Username == username).FirstOrDefault();
#pragma warning restore CS8603 // Possible null reference return.
            }
        }
        public User GetUserByUsername(string username)
        {
            using (var connection = new SqlConnection(sett.ConnectionStrings))
            {
                // Assuming there is an Email property in the User model
#pragma warning disable CS8603 // Possible null reference return.
                return connection.Query<User>(e => e.Username == username).FirstOrDefault();
#pragma warning restore CS8603 // Possible null reference return.
            }
        }








    }


    public class EmployeeRepository : BaseRepository<Employee, SqlConnection>
    {
        Setting sett = new Setting();

        public EmployeeRepository(Setting sett) : base(sett.ConnectionStrings)
        {
            this.sett = sett;
            DbSettingMapper.Add<SqlConnection>(new SqlServerDbSetting(), true);
            DbHelperMapper.Add<SqlConnection>(new SqlServerDbHelper(), true);
            StatementBuilderMapper.Add<SqlConnection>(new SqlServerStatementBuilder(new SqlServerDbSetting()), true);
        }

        public void InsertEmployee(Employee employee)
        {
            using (var connection = new SqlConnection(sett.ConnectionStrings))
            {
                connection.Insert(employee);
            }
        }

        public void UpdateUser(Employee employee)
        {
            using (var connection = new SqlConnection(sett.ConnectionStrings))
            {
                connection.Update(employee);
            }
        }

        public int DeleteUser(Employee employee)
        {
            using (var connection = new SqlConnection(sett.ConnectionStrings))
            {
                return connection.Delete<Employee>(employee);
            }
        }

        public List<Employee> GetUsers()
        {
            var users = new List<Employee>();
            using (var connection = new SqlConnection(sett.ConnectionStrings))
            {

                users = connection.QueryAll<Employee>().ToList();
            }
            return users;
        }

        public Employee GetUser(int id)
        {
            using (var connection = new SqlConnection(sett.ConnectionStrings))
            {
#pragma warning disable CS8603 // Possible null reference return.
                return connection.Query<Employee>(id).FirstOrDefault();
#pragma warning restore CS8603 // Possible null reference return.
            }
        }
        public UserCredentials GetUserByEmail(string username)
        {
            using (var connection = new SqlConnection(sett.ConnectionStrings))
            {
                // Assuming there is an Email property in the User model
#pragma warning disable CS8603 // Possible null reference return.
                return connection.Query<UserCredentials>(e => e.Username == username).FirstOrDefault();
#pragma warning restore CS8603 // Possible null reference return.
            }
        }
        //         public Employee GetUserByUsername(string username)
        //         {
        //             using (var connection = new SqlConnection(sett.ConnectionStrings))
        //             {
        //                 // Assuming there is an Email property in the User model
        // #pragma warning disable CS8603 // Possible null reference return.
        //                 return connection.Query<Employee>(e => e.Username == username).FirstOrDefault();
        // #pragma warning restore CS8603 // Possible null reference return.
        //             }
        //         }








    }

    public class PatientRepository : BaseRepository<Patient, SqlConnection>
    {
        Setting sett = new Setting();

        public PatientRepository(Setting sett) : base(sett.ConnectionStrings)
        {
            this.sett = sett;
            DbSettingMapper.Add<SqlConnection>(new SqlServerDbSetting(), true);
            DbHelperMapper.Add<SqlConnection>(new SqlServerDbHelper(), true);
            StatementBuilderMapper.Add<SqlConnection>(new SqlServerStatementBuilder(new SqlServerDbSetting()), true);
        }

        public void InsertPatient(Patient patient)
        {
            using (var connection = new SqlConnection(sett.ConnectionStrings))
            {
                connection.Insert(patient);
            }
        }

        public void UpdatePatient(Patient patient)
        {
            using (var connection = new SqlConnection(sett.ConnectionStrings))
            {
                connection.Update(patient);
            }
        }

        public int GetLatestPatientUlid()
        {

            using (var connection = new SqlConnection(sett.ConnectionStrings))
            {

                var query = "SELECT MAX(ulid)   FROM [Auction_Test].[dbo].[patients]";
                return connection.ExecuteQuery<int>(query).FirstOrDefault();
            }
        }

        public int DeletePatient(Patient patient)
        {
            using (var connection = new SqlConnection(sett.ConnectionStrings))
            {
                return connection.Delete<Patient>(patient);
            }
        }

        public List<Patient> GetPatients()
        {
            var patients = new List<Patient>();
            using (var connection = new SqlConnection(sett.ConnectionStrings))
            {
                patients = connection.QueryAll<Patient>().ToList();
            }
            return patients;
        }

        public Patient GetPatientById(int id)
        {
            using (var connection = new SqlConnection(sett.ConnectionStrings))
            {
#pragma warning disable CS8603 // Possible null reference return.
                return connection.Query<Patient>(id).FirstOrDefault();
#pragma warning restore CS8603 // Possible null reference return.
            }
        }

        public List<Patient> GetValidatedPatientByUser(int enteredByUserId)
        {
            try
            {
                using (var connection = new SqlConnection(sett.ConnectionStrings))
                {
                    return connection.ExecuteQuery<Patient>("usp_getValidatedPatientByUser", new { entered_by_user_id = enteredByUserId },
                          commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                throw new ApplicationException($"Error getting validated patients by user: {ex.Message}", ex);
            }
        }
        public Patient GetValidatedPatientByIDandUserID(int patientId, int requestId)
        {
            using (var connection = new SqlConnection(sett.ConnectionStrings))
            {
                var result = connection
                    .ExecuteQuery<Patient>(
                        "usp_getValidatedPatientByIDandUserID",
                        new { request_id = requestId, patient_id = patientId },
                        commandType: CommandType.StoredProcedure
                    )
                    .FirstOrDefault();
                if (result == null)
                {

                }
#pragma warning disable CS8603 // Possible null reference return.
                return result;
#pragma warning restore CS8603 // Possible null reference return.
            }
        }
        public Patient GetPatientByUlid(int ulid)
        {
            using (var connection = new SqlConnection(sett.ConnectionStrings))
            {
                var query = "SELECT * FROM [Auction_Test].[dbo].[patients] WHERE ulid = @ulid";
#pragma warning disable CS8603 // Possible null reference return.
                return connection.ExecuteQuery<Patient>(query, new { ulid = ulid }).FirstOrDefault();
#pragma warning restore CS8603 // Possible null reference return.
            }
        }





    }

    public class PatientFilesRepository : BaseRepository<PatientFilesModel, SqlConnection>
    {
        Setting sett = new Setting();

        public PatientFilesRepository(Setting sett) : base(sett.ConnectionStrings)
        {
            this.sett = sett;
            DbSettingMapper.Add<SqlConnection>(new SqlServerDbSetting(), true);
            DbHelperMapper.Add<SqlConnection>(new SqlServerDbHelper(), true);
            StatementBuilderMapper.Add<SqlConnection>(new SqlServerStatementBuilder(new SqlServerDbSetting()), true);
        }

        public void AddImageAsync(PatientFilesModel patientFilesModel)
        {
            using (var connection = new SqlConnection(sett.ConnectionStrings))
            {
                connection.Insert(patientFilesModel);

            }
        }
        public PatientFilesModel GetById(int id)
        {
            using (var connection = new SqlConnection(sett.ConnectionStrings))
            {
#pragma warning disable CS8603 // Possible null reference return.
                return connection.Query<PatientFilesModel>(where: x => x.Id == id).FirstOrDefault();
#pragma warning restore CS8603 // Possible null reference return.
            }
        }



        // Implement other repository methods...
    }


    
    public class ResultFilesRepository : BaseRepository<ResultFiles, SqlConnection>
    {
        Setting sett = new Setting();

        public ResultFilesRepository(Setting sett) : base(sett.ConnectionStrings)
        {
            this.sett = sett;
            DbSettingMapper.Add<SqlConnection>(new SqlServerDbSetting(), true);
            DbHelperMapper.Add<SqlConnection>(new SqlServerDbHelper(), true);
            StatementBuilderMapper.Add<SqlConnection>(new SqlServerStatementBuilder(new SqlServerDbSetting()), true);
        }

        public void AddFileAsync(ResultFiles resultFiles)
        {
            using (var connection = new SqlConnection(sett.ConnectionStrings))
            {
                connection.Insert(resultFiles);

            }
        }
        public ResultFiles GetById(int id)
        {
            using (var connection = new SqlConnection(sett.ConnectionStrings))
            {
#pragma warning disable CS8603 // Possible null reference return.
                return connection.Query<ResultFiles>(where: x => x.id == id).FirstOrDefault();
#pragma warning restore CS8603 // Possible null reference return.
            }
        }



        // Implement other repository methods...
    }




    public class UsersRolesRepository : BaseRepository<User, SqlConnection>
    {
        Setting sett = new Setting();

        public UsersRolesRepository(Setting sett) : base(sett.ConnectionStrings)
        {
            this.sett = sett;
            DbSettingMapper.Add<SqlConnection>(new SqlServerDbSetting(), true);
            DbHelperMapper.Add<SqlConnection>(new SqlServerDbHelper(), true);
            StatementBuilderMapper.Add<SqlConnection>(new SqlServerStatementBuilder(new SqlServerDbSetting()), true);
        }

        public void InsertUserRole(UsersRoles usersRoles)
        {
            using (var connection = new SqlConnection(sett.ConnectionStrings))
            {
                connection.Insert(usersRoles);
            }
        }

        public void UpdateUserRole(UsersRoles usersRoles)
        {
            using (var connection = new SqlConnection(sett.ConnectionStrings))
            {
                connection.Update(usersRoles);
            }
        }

        public int DeleteUserRole(UsersRoles usersRoles)
        {
            using (var connection = new SqlConnection(sett.ConnectionStrings))
            {
                return connection.Delete<User>(usersRoles);
            }
        }

        public List<UsersRoles> GetUserRoles()
        {
            var userRoles = new List<UsersRoles>();
            using (var connection = new SqlConnection(sett.ConnectionStrings))
            {
                userRoles = connection.QueryAll<UsersRoles>().ToList();
            }
            return userRoles;
        }

        public UsersRoles GetUserRoleById(int id)
        {
            using (var connection = new SqlConnection(sett.ConnectionStrings))
            {
#pragma warning disable CS8603 // Possible null reference return.
                return connection.Query<UsersRoles>(id).FirstOrDefault();
#pragma warning restore CS8603 // Possible null reference return.
            }
        }
        public UsersRoles GetUserRoleByUserId(int user_id)
        {
            using (var connection = new SqlConnection(sett.ConnectionStrings))
            {
                var sql = "SELECT * FROM usersroles WHERE User_Id = @user_id";
#pragma warning disable CS8603 // Possible null reference return.
                return connection.Query<UsersRoles>(sql, new { user_id }).FirstOrDefault();
#pragma warning restore CS8603 // Possible null reference return.
            }
        }

        public List<UsersRoles> GetUserRolesByUserIdFromView(int userId)
        {
            try
            {
                using (var connection = new SqlConnection(sett.ConnectionStrings))
                {
                    return connection.ExecuteQuery<UsersRoles>(
                        "getUserRolesByUserIdFromView",
                        new { UserId = userId },
                        commandType: CommandType.StoredProcedure
                    ).ToList();
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                throw new ApplicationException($"Error getting user roles from view: {ex.Message}", ex);
            }
        }
        public UsersRoles GetEmployeeTypeFromUserId(int user_Id)
        {
            try
            {
                using (var connection = new SqlConnection(sett.ConnectionStrings))
                {
#pragma warning disable CS8603 // Possible null reference return.
                    return connection.ExecuteQuery<UsersRoles>(
                    "getEmployeeTypeFromUserId",
                    new { user_Id = user_Id },
                    commandType: CommandType.StoredProcedure
                ).FirstOrDefault();
#pragma warning restore CS8603 // Possible null reference return.
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                throw new ApplicationException($"Error getting employee type from user: {ex.Message}", ex);
            }
        }
    }








    public class DepartmentRepository : BaseRepository<Department, SqlConnection>
    {
        Setting sett = new Setting();

        public DepartmentRepository(Setting sett) : base(sett.ConnectionStrings)
        {
            this.sett = sett;
            DbSettingMapper.Add<SqlConnection>(new SqlServerDbSetting(), true);
            DbHelperMapper.Add<SqlConnection>(new SqlServerDbHelper(), true);
            StatementBuilderMapper.Add<SqlConnection>(new SqlServerStatementBuilder(new SqlServerDbSetting()), true);
        }

        public void InsertDepartment(Department department)
        {
            using (var connection = new SqlConnection(sett.ConnectionStrings))
            {
                connection.Insert(department);
            }
        }

        public List<Department> GetDepartments()
        {
            var departments = new List<Department>();
            using (var connection = new SqlConnection(sett.ConnectionStrings))
            {
                departments = connection.QueryAll<Department>().ToList();
            }
            return departments;
        }

        public Department GetDepartmentById(int id)
        {
            using (var connection = new SqlConnection(sett.ConnectionStrings))
            {
#pragma warning disable CS8603 // Possible null reference return.
                return connection.Query<Department>(id).FirstOrDefault();
#pragma warning restore CS8603 // Possible null reference return.
            }
        }
    }

    //     public class ShiftRepository : BaseRepository<Shift, SqlConnection>
    //     {
    //         Setting sett = new Setting();

    //         public ShiftRepository(Setting sett) : base(sett.ConnectionStrings)
    //         {
    //             this.sett = sett;
    //             DbSettingMapper.Add<SqlConnection>(new SqlServerDbSetting(), true);
    //             DbHelperMapper.Add<SqlConnection>(new SqlServerDbHelper(), true);
    //             StatementBuilderMapper.Add<SqlConnection>(new SqlServerStatementBuilder(new SqlServerDbSetting()), true);
    //         }

    //         public void InsertShift(Shift shift)
    //         {
    //             using (var connection = new SqlConnection(sett.ConnectionStrings))
    //             {
    //                 connection.Insert(shift);
    //             }
    //         }

    //         public List<Shift> GetShifts()
    //         {
    //             var shifts = new List<Shift>();
    //             using (var connection = new SqlConnection(sett.ConnectionStrings))
    //             {
    //                 shifts = connection.QueryAll<Shift>().ToList();
    //             }
    //             return shifts;
    //         }

    //         public Shift GetShiftById(int id)
    //         {
    //             using (var connection = new SqlConnection(sett.ConnectionStrings))
    //             {
    // #pragma warning disable CS8603 // Possible null reference return.
    //                 return connection.Query<Shift>(id).FirstOrDefault();
    // #pragma warning restore CS8603 // Possible null reference return.
    //             }
    //         }
    //     }

    public class EmployeeTypeRepository : BaseRepository<EmployeeType, SqlConnection>
    {
        Setting sett = new Setting();

        public EmployeeTypeRepository(Setting sett) : base(sett.ConnectionStrings)
        {
            this.sett = sett;
            DbSettingMapper.Add<SqlConnection>(new SqlServerDbSetting(), true);
            DbHelperMapper.Add<SqlConnection>(new SqlServerDbHelper(), true);
            StatementBuilderMapper.Add<SqlConnection>(new SqlServerStatementBuilder(new SqlServerDbSetting()), true);
        }

        public void InsertEmpType(EmployeeType empType)
        {
            using (var connection = new SqlConnection(sett.ConnectionStrings))
            {
                connection.Insert(empType);
            }
        }

        public List<EmployeeType> GetEmpTypes()
        {
            var emptypes = new List<EmployeeType>();
            using (var connection = new SqlConnection(sett.ConnectionStrings))
            {
                emptypes = connection.QueryAll<EmployeeType>().ToList();
            }
            return emptypes;
        }

        public EmployeeType GetEmpTypeById(int id)
        {
            using (var connection = new SqlConnection(sett.ConnectionStrings))
            {
#pragma warning disable CS8603 // Possible null reference return.
                return connection.Query<EmployeeType>(id).FirstOrDefault();
#pragma warning restore CS8603 // Possible null reference return.
            }
        }
    }



    public class SampleDetailRepository : BaseRepository<SampleDetail, SqlConnection>
    {
        Setting sett = new Setting();
        public SampleDetailRepository(Setting sett) : base(sett.ConnectionStrings)
        {
            this.sett = sett;
            DbSettingMapper.Add<SqlConnection>(new SqlServerDbSetting(), true);
            DbHelperMapper.Add<SqlConnection>(new SqlServerDbHelper(), true);
        }

        public void InsertSampleDetail(SampleDetail sampleDetail)
        {
            using (var connection = new SqlConnection(sett.ConnectionStrings))
            {
                connection.Insert(sampleDetail);
            }
        }

        public SampleDetail GetSampleDetailById(int id)
        {
            using (var connection = new SqlConnection(sett.ConnectionStrings))
            {
                return connection.Query<SampleDetail>(id).FirstOrDefault();
            }
        }

        public IEnumerable<SampleDetail> GetSampleDetails()
        {
            using (var connection = new SqlConnection(sett.ConnectionStrings))
            {
                return connection.QueryAll<SampleDetail>();
            }
        }

        public SampleDetail GetSampleDetailsBySampleNo(int sampleNo)
        {
            using (var connection = new SqlConnection(sett.ConnectionStrings))
            {
                 var sampleDetail = connection.Query<SampleDetail>(e => e.sampleNo == sampleNo).FirstOrDefault();

                 if (sampleDetail != null)
                 {
                    // Retrieve employee details for each sample
                    sampleDetail.cemployee = connection.Query<Employee>(e => e.id == sampleDetail.collectedBy).FirstOrDefault();
                    sampleDetail.aemployee = connection.Query<Employee>(e => e.id == sampleDetail.acknowledgedBy).FirstOrDefault();
                    sampleDetail.demployee = connection.Query<Employee>(e => e.id == sampleDetail.dispatchedBy).FirstOrDefault();
                 }

                return sampleDetail;
      
            }
        }
         public void UpdateSampleDetail(SampleDetail sampleDetail)
        {
            using (var connection = new SqlConnection(sett.ConnectionStrings))
            {
                connection.Update(sampleDetail);
            }
        }

        // Add other methods as per your requirements
    }

     public class SamplePerServiceRepository : BaseRepository<SamplePerService, SqlConnection>
    {
        Setting sett = new Setting();
        public SamplePerServiceRepository(Setting sett) : base(sett.ConnectionStrings)
        {
            this.sett = sett;
            DbSettingMapper.Add<SqlConnection>(new SqlServerDbSetting(), true);
            DbHelperMapper.Add<SqlConnection>(new SqlServerDbHelper(), true);
        }

        public void InsertSamplePerService(SamplePerService samplePerService)
        {
            using (var connection = new SqlConnection(sett.ConnectionStrings))
            {
                connection.Insert(samplePerService);
            }
        }

        public SamplePerService GetSamplePerServiceById(int id)
        {
            using (var connection = new SqlConnection(sett.ConnectionStrings))
            {
                return connection.Query<SamplePerService>(id).FirstOrDefault();
            }
        }

        public IEnumerable<SamplePerService> GetSamplePerServices()
        {
            using (var connection = new SqlConnection(sett.ConnectionStrings))
            {
                return connection.QueryAll<SamplePerService>();
            }
        }

        // public IEnumerable<SamplePerService> GetSamplePerServicesBySampleNo(int sampleNo)
        // {
        //     using (var connection = new SqlConnection(sett.ConnectionStrings))
        //     {
        //         return connection.Query<SamplePerService>(e => e.sampleNo == sampleNo);
        //     }
        // }
        public IEnumerable<SamplePerService> GetSamplePerServicesBySampleNo(int sampleNo)
        {
            using (var connection = new SqlConnection(sett.ConnectionStrings))
            {
                var samplePerServices = connection.Query<SamplePerService>(e => e.sampleNo == sampleNo).ToList();
                // var samplePerService = new samplePerServices();
                

                // Query status master for each samplePerService
                foreach (var samplePerService in samplePerServices)
                {
                    samplePerService.statusMaster =connection.Query<StatusMaster>(e => e.id == samplePerService.statusId).FirstOrDefault();
                    samplePerService.servmaster = connection.Query<ServiceMaster>(e => e.id == samplePerService.serviceId).FirstOrDefault();
                    samplePerService.sampleDetail = connection.Query<SampleDetail>(e => e.sampleNo == samplePerService.sampleNo).FirstOrDefault();
                    samplePerService.cemployee = connection.Query<Employee>(e => e.id == samplePerService.sampleDetail.collectedBy).FirstOrDefault();
                    samplePerService.aemployee = connection.Query<Employee>(e => e.id == samplePerService.sampleDetail.acknowledgedBy).FirstOrDefault();
                    samplePerService.demployee = connection.Query<Employee>(e => e.id == samplePerService.sampleDetail.dispatchedBy).FirstOrDefault();

                    //  connection.Query<StatusMaster>("SELECT * FROM [StatusMaster] WHERE Id = @StatusId", new { StatusId = samplePerService.statusId }).FirstOrDefault();
                    // samplePerService.statusMaster = statusMaster;
                }

                return samplePerServices;
            }
        }
        public IEnumerable<ViewUniqueSamplePerService> GetViewUniqueSamplePerServiceByUlid(int ulid)
        {
            using (var connection = new SqlConnection(sett.ConnectionStrings))
            {
                return connection.Query<ViewUniqueSamplePerService>(e => e.ulid == ulid);
            }
        
        }


        // Add other methods as per your requirements
        public int GetLatestSampleNo()
        {

            using (var connection = new SqlConnection(sett.ConnectionStrings))
            {

                var query = "SELECT MAX(sampleNo)   FROM [Auction_Test].[dbo].[sampleperservice]";
                return connection.ExecuteQuery<int>(query).FirstOrDefault();
            }
        }
         public void UpdateSamplePerService(SamplePerService samplePerService)
        {
            using (var connection = new SqlConnection(sett.ConnectionStrings))
            {
                connection.Update(samplePerService);
            }
        }
    //   public IEnumerable<SamplePerService> GetFilteredSamples(int sampleNo, int ulid, string status, DateTime startDate, DateTime endDate)
    //     {
    //         var sql = @"
    //             EXEC [dbo].[GetFilteredSamples]
    //             @startDate = @startDate,
    //             @endDate = @endDate,
    //             @sampleNo = @sampleNo,
    //             @ulid = @ulid,
    //             @status = @status;";

    //         // Execute the stored procedure and return the result
    //         return ExecuteQuery<SamplePerService>(sql, new
    //         {
    //             startDate,
    //             endDate,
    //             sampleNo,
    //             ulid,
    //             status
    //         });
    //     }
        public List<ViewUniqueSamplePerService> GetFilteredSamples(int? sampleNo, int? ulid, int? statusId, DateTime startDate, DateTime endDate)
        {
            List<ViewUniqueSamplePerService> samples = new List<ViewUniqueSamplePerService>();
            using (var connection = new SqlConnection(sett.ConnectionStrings))
            {
                var parameters = new
                {
                    startDate = startDate,
                    endDate = endDate,
                    sampleNo = sampleNo ?? (object)DBNull.Value,
                    ulid = ulid ?? (object)DBNull.Value,
                    statusId = statusId ?? (object)DBNull.Value,
                };

                samples = connection.ExecuteQuery<ViewUniqueSamplePerService>(
                    "[dbo].[GetFilteredSamples]",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                ).ToList();
            }
            return samples;
        }

        public List<RequestedServiceViewModel> GetFilteredRequestedServices(
            DateTime startDate, 
            DateTime endDate, 
            int? sampleNo, 
            int? sampleUlid, 
            int? sampleStatusId, 
            int? stageId, 
            int? sampleServiceId, 
            int? sampleHistoNo)
        {
            List<RequestedServiceViewModel> requestedServices = new List<RequestedServiceViewModel>();
            using (var connection = new SqlConnection(sett.ConnectionStrings))
            {
                var parameters = new
                {
                    @startDate = startDate,
                    @endDate = endDate,
                    @sampleNo = sampleNo ?? (object)DBNull.Value,
                    @sampleUlid = sampleUlid ?? (object)DBNull.Value,
                    @sampleStatusId = sampleStatusId ?? (object)DBNull.Value,
                    @stageId = stageId ?? (object)DBNull.Value,
                    @sampleServiceId = sampleServiceId ?? (object)DBNull.Value,
                    @sampleHistoNo = sampleHistoNo ?? (object)DBNull.Value,
                };

                requestedServices = connection.ExecuteQuery<RequestedServiceViewModel>(
                    "[dbo].[usp_requestedServiceMaster]", // Update the stored procedure name if necessary
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                ).ToList();
            }
            return requestedServices;
        }



    }
    public class HistologySampleRepository : BaseRepository<HistologySample, SqlConnection>
    {
        Setting sett = new Setting();
        public HistologySampleRepository(Setting sett) : base(sett.ConnectionStrings)
        {
            this.sett = sett;
            DbSettingMapper.Add<SqlConnection>(new SqlServerDbSetting(), true);
            DbHelperMapper.Add<SqlConnection>(new SqlServerDbHelper(), true);
        }

        // Other existing methods...

        public void InsertHistologySample(HistologySample histologySample)
        {
            using (var connection = new SqlConnection(sett.ConnectionStrings))
            {
                connection.Insert(histologySample);
            }
        }

        public HistologySample GetHistologySampleById(int id)
        {
            using (var connection = new SqlConnection(sett.ConnectionStrings))
            {
                return connection.Query<HistologySample>(id).FirstOrDefault();
            }
        }

        public IEnumerable<HistologySample> GetHistologySamples()
        {
            using (var connection = new SqlConnection(sett.ConnectionStrings))
            {
                return connection.QueryAll<HistologySample>();
            }
        }

        public void UpdateHistologySample(HistologySample histologySample)
        {
            using (var connection = new SqlConnection(sett.ConnectionStrings))
            {
                connection.Update(histologySample);
            }
        }

        // Add other methods as per your requirements
         public int GetLatestHistoNo()
        {

            using (var connection = new SqlConnection(sett.ConnectionStrings))
            {

                var query = "SELECT MAX(histoNo)   FROM [Auction_Test].[dbo].[histologySample]";
                return connection.ExecuteQuery<int>(query).FirstOrDefault();
            }
        }
        public HistologySample GetHistologySampleByHistoNo(int histoNo)
        {
            using (var connection = new SqlConnection(sett.ConnectionStrings))
            {
                return connection.Query<HistologySample>(e => e.histoNo == histoNo).FirstOrDefault();
            }
        }
        public HistologySample GetHistologySampleBySampleNo(int sampleNo)
        {
            using (var connection = new SqlConnection(sett.ConnectionStrings))
            {
                 var sampleDetail = connection.Query<HistologySample>(e => e.sampleNo == sampleNo).FirstOrDefault();

                 if (sampleDetail != null)
                 {
                    // Retrieve employee details for each sample
                    sampleDetail.gemployee = connection.Query<Employee>(e => e.id == sampleDetail.sampleGrossingPerformedBy).FirstOrDefault();
                    sampleDetail.temployee = connection.Query<Employee>(e => e.id == sampleDetail.tissueProcessingPerformedBy).FirstOrDefault();
                    sampleDetail.eemployee = connection.Query<Employee>(e => e.id == sampleDetail.embeddingPerformedBy).FirstOrDefault();
                    sampleDetail.memployee = connection.Query<Employee>(e => e.id == sampleDetail.microtomyPerformedBy).FirstOrDefault();
                    sampleDetail.semployee = connection.Query<Employee>(e => e.id == sampleDetail.stainingPerformedBy).FirstOrDefault();
                    sampleDetail.serviceMaster =  connection.Query<ServiceMaster>(e => e.id == sampleDetail.serviceId).FirstOrDefault();
                    // sampleDetail.samplePerService = connection.Query<SamplePerService>(e => e.id == sampleDetail.sampleNo).FirstOrDefault();

                 }

                return sampleDetail;
      
            }
        }
    }


    public class CollectionSiteRepository : BaseRepository<CollectionSite, SqlConnection>
    {
        Setting sett = new Setting();
        public CollectionSiteRepository(Setting sett) : base(sett.ConnectionStrings)
        {
            this.sett = sett;
            DbSettingMapper.Add<SqlConnection>(new SqlServerDbSetting(), true);
            DbHelperMapper.Add<SqlConnection>(new SqlServerDbHelper(), true);
        }

        public void Insert(CollectionSite collectionSite)
        {
            using (var connection = new SqlConnection(sett.ConnectionStrings))
            {
                connection.Insert(collectionSite);
            }
        }

        public void Update(CollectionSite collectionSite)
        {
            using (var connection = new SqlConnection(sett.ConnectionStrings))
            {
                connection.Update(collectionSite);
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(sett.ConnectionStrings))
            {
                connection.Delete<CollectionSite>(id);
            }
        }

        public List<CollectionSite> GetAll()
        {
            using (var connection = new SqlConnection(sett.ConnectionStrings))
            {
                return connection.QueryAll<CollectionSite>().ToList();
            }
        }

        public CollectionSite GetById(int id)
        {
            using (var connection = new SqlConnection(sett.ConnectionStrings))
            {
                return connection.Query<CollectionSite>(id).FirstOrDefault();
            }
        }
    }

    public class SampleTypeMasterRepository : BaseRepository<SampleTypeMaster, SqlConnection>
    {
        Setting sett = new Setting();
        public SampleTypeMasterRepository(Setting sett) : base(sett.ConnectionStrings)
        {
            this.sett = sett;
            DbSettingMapper.Add<SqlConnection>(new SqlServerDbSetting(), true);
            DbHelperMapper.Add<SqlConnection>(new SqlServerDbHelper(), true);
        }
       
        public void Insert(SampleTypeMaster sampleTypeMaster)
        {
            using (var connection = new SqlConnection(sett.ConnectionStrings))
            {
                connection.Insert(sampleTypeMaster);
            }
        }

        public void Update(SampleTypeMaster sampleTypeMaster)
        {
            using (var connection = new SqlConnection(sett.ConnectionStrings))
            {
                connection.Update(sampleTypeMaster);
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(sett.ConnectionStrings))
            {
                connection.Delete<SampleTypeMaster>(id);
            }
        }

        public List<SampleTypeMaster> GetAll()
        {
            using (var connection = new SqlConnection(sett.ConnectionStrings))
            {
                return connection.QueryAll<SampleTypeMaster>().ToList();
            }
        }

        public SampleTypeMaster GetById(int id)
        {
            using (var connection = new SqlConnection(sett.ConnectionStrings))
            {
                return connection.Query<SampleTypeMaster>(id).FirstOrDefault();
            }
        }
    }

    public class ReferralTypeRepository : BaseRepository<ReferralType, SqlConnection>
    {
        Setting sett = new Setting();
        public ReferralTypeRepository(Setting sett) : base(sett.ConnectionStrings)
        {
            this.sett = sett;
            DbSettingMapper.Add<SqlConnection>(new SqlServerDbSetting(), true);
            DbHelperMapper.Add<SqlConnection>(new SqlServerDbHelper(), true);
        }
      
        public void Insert(ReferralType referralType)
        {
            using (var connection = new SqlConnection(sett.ConnectionStrings))
            {
                connection.Insert(referralType);
            }
        }

        public void Update(ReferralType referralType)
        {
            using (var connection = new SqlConnection(sett.ConnectionStrings))
            {
                connection.Update(referralType);
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(sett.ConnectionStrings))
            {
                connection.Delete<ReferralType>(id);
            }
        }

        public List<ReferralType> GetAll()
        {
            using (var connection = new SqlConnection(sett.ConnectionStrings))
            {
                return connection.QueryAll<ReferralType>().ToList();
            }
        }

        public ReferralType GetById(int id)
        {
            using (var connection = new SqlConnection(sett.ConnectionStrings))
            {
                return connection.Query<ReferralType>(id).FirstOrDefault();
            }
        }
    }
    public class ServiceMasterRepository : BaseRepository<ServiceMaster, SqlConnection>
    {
        Setting sett = new Setting();
        public ServiceMasterRepository(Setting sett) : base(sett.ConnectionStrings)
        {
            this.sett = sett;
            DbSettingMapper.Add<SqlConnection>(new SqlServerDbSetting(), true);
            DbHelperMapper.Add<SqlConnection>(new SqlServerDbHelper(), true);
        }
      
     
        public void Insert(ServiceMaster serviceMaster)
        {
            using (var connection = new SqlConnection(sett.ConnectionStrings))
            {
                connection.Insert(serviceMaster);
            }
        }

        public void Update(ServiceMaster serviceMaster)
        {
            using (var connection = new SqlConnection(sett.ConnectionStrings))
            {
                connection.Update(serviceMaster);
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(sett.ConnectionStrings))
            {
                connection.Delete<ServiceMaster>(id);
            }
        }

        public List<ServiceMaster> GetAll()
        {
            using (var connection = new SqlConnection(sett.ConnectionStrings))
            {
                return connection.QueryAll<ServiceMaster>().ToList();
            }
        }

        public ServiceMaster GetById(int id)
        {
            using (var connection = new SqlConnection(sett.ConnectionStrings))
            {
                return connection.Query<ServiceMaster>(id).FirstOrDefault();
            }
        }
    }

      public class StatusMasterRepository : BaseRepository<StatusMaster, SqlConnection>
    {
        Setting sett = new Setting();

        public StatusMasterRepository(Setting sett) : base(sett.ConnectionStrings)
        {
            this.sett = sett;
            DbSettingMapper.Add<SqlConnection>(new SqlServerDbSetting(), true);
            DbHelperMapper.Add<SqlConnection>(new SqlServerDbHelper(), true);
            StatementBuilderMapper.Add<SqlConnection>(new SqlServerStatementBuilder(new SqlServerDbSetting()), true);
        }

        public void Insert(StatusMaster statusMaster)
        {
            using (var connection = new SqlConnection(sett.ConnectionStrings))
            {
                connection.Insert(statusMaster);
            }
        }

        public void Update(StatusMaster statusMaster)
        {
            using (var connection = new SqlConnection(sett.ConnectionStrings))
            {
                connection.Update(statusMaster);
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(sett.ConnectionStrings))
            {
                connection.Delete<StatusMaster>(id);
            }
        }

        public List<StatusMaster> GetAll()
        {
            using (var connection = new SqlConnection(sett.ConnectionStrings))
            {
                return connection.QueryAll<StatusMaster>().ToList();
            }
        }

        public StatusMaster GetById(int id)
        {
            using (var connection = new SqlConnection(sett.ConnectionStrings))
            {
                return connection.Query<StatusMaster>(id).FirstOrDefault();
            }
        }

        public IEnumerable<StatusMaster> GetStatusMasterByStatusType(string statusType)
        {
            using (var connection = new SqlConnection(sett.ConnectionStrings))
            {
                return connection.Query<StatusMaster>(e => e.statusType == statusType).ToList();
            }
        }
    }



}
