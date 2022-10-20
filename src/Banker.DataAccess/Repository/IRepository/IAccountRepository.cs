using Microsoft.Identity.Client;

namespace Banker.DataAccess.Repository.IRepository;

public interface IAccountRepository
{
    Task<AccountDto> GetAccountByIdAsync(int accountId);

    Task<IEnumerable<AccountDto>> GetAccountsAsync();

    Task<AccountDto> CreateAccountAsync(AccountDto account);

    Task<AccountDto> UpdateAccountAsync(AccountDto account);

    Task<bool> DeleteAccountAsync(int accountId);
}