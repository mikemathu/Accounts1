﻿using Accounts.Models.VM;
using Accounts.Services;
using Npgsql;

namespace Accounts.Repositories
{
    public class FiscalRepository : IFiscalPeriods
    {
        private const string _fiscalPeriodsTable = "FiscalPeriods";
        private const string _accountDetailsTable = "AccountDetails";
        private IConfiguration _config;
        private NpgsqlConnection _connection;
        public FiscalRepository(IConfiguration config)
        {
            _config = config;
        }
        private void OpenConnection()
        {
            string connectionString = _config.GetConnectionString("DefaultConnection");

            _connection = new NpgsqlConnection(connectionString);
            _connection.Open();
        }

        public async Task<IEnumerable<FiscalPeriodVM>> GetFiscalPeriods()
        {
            OpenConnection();
            List<FiscalPeriodVM> fiscalPeriods = new List<FiscalPeriodVM>();

            var commandText = $"SELECT * FROM {_fiscalPeriodsTable} ";
            using (NpgsqlCommand command = new NpgsqlCommand(commandText, _connection))
            {
                using (NpgsqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        fiscalPeriods.Add(new FiscalPeriodVM
                        {
                            Id = (int)reader["Id"],
                            OpenDate = (DateTime)reader["OpenDate"],
                            CloseDate = (DateTime)reader["CloseDate"],
                            IsActive = (int)reader["IsActive"],
                            IsOpen = (int)reader["IsOpen"]
                        });
                    }
                    reader.Close();
                }
                _connection.Close();
            }
            if (fiscalPeriods.Count() == 0)
                return null;
            return fiscalPeriods;
        }

        public async Task<IEnumerable<AccountDetailVM>> GetAccountsDetails()
        {
            OpenConnection();
            List<AccountDetailVM> accountDetails = new List<AccountDetailVM>();

            string commandText = $"SELECT * FROM {_accountDetailsTable} ";
            using (NpgsqlCommand command = new NpgsqlCommand(commandText, _connection))
            {
                using (NpgsqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        accountDetails.Add(new AccountDetailVM
                        {
                            Id = (int)reader["Id"],
                            AccountName = (string)reader["AccountName"],
                            AccountClass = (string)reader["AccountClass"]
                        });
                    }
                    reader.Close();
                }
                _connection.Close();
            }
            if (accountDetails.Count() == 0)
                return null;
            return accountDetails;
        }
    }
}
