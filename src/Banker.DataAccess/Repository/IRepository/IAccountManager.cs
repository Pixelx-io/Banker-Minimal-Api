namespace Banker.DataAccess.Repository.IRepository;

public interface IAccountManager
{
    Task<AccountDto> GetAccountByIdAsync(int id);

    Task<AccountDto> GetAccountByEmailAsync(string email);

    Task<AccountDto> InsertAccountAsync(AccountDto account);

    Task<AccountDto> UpdateAccountAsync(AccountDto account);

    Task<AccountDto> DeleteAccountAsync(int id);
}