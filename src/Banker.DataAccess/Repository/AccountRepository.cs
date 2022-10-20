using Banker.DataAccess.Repository.IRepository;

namespace Banker.DataAccess.Repository;

public class AccountRepository : IAccountRepository
{
    private readonly ApplicationDbContext _db;
    private readonly IMapper _mapper;

    public AccountRepository(ApplicationDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<AccountDto> GetAccountByIdAsync(int accountId)
    {
        var resultsFromDb = await _db.Accounts.FirstOrDefaultAsync(a => a.Id == accountId);

        if (resultsFromDb is null)
            new AccountDto();

        var mappedResults = _mapper.Map<AccountDto>(resultsFromDb);

        return mappedResults;
    }

    public async Task<IEnumerable<AccountDto>> GetAccountsAsync()
    {
        var resultsFromDb = await _db.Accounts.ToListAsync();

        if (!resultsFromDb.Any())
            return Enumerable.Empty<AccountDto>();

        var mappedResults = _mapper.Map<IEnumerable<AccountDto>>(resultsFromDb);

        return mappedResults;
    }

    public async Task<AccountDto> CreateAccountAsync(AccountDto account)
    {
        var isAvailable = await _db.Accounts
            .FirstOrDefaultAsync(a => a.Name == account.Name || a.Email == account.Email);

        if(isAvailable is not null)
            return new AccountDto();

        var mappedResults = _mapper.Map<AccountModel>(account);

        _db.Accounts.Add(mappedResults);

        var isSuccess = await _db.SaveChangesAsync();

        return isSuccess == 1 ? account : new AccountDto();
    }

    public async Task<AccountDto> UpdateAccountAsync(AccountDto account)
    {
        var isAvailable = await _db.Accounts
            .FirstOrDefaultAsync(a => a.Name == account.Name || a.Email == account.Email);

        if (isAvailable is not null)
            return new AccountDto();

        var mappedResults = _mapper.Map<AccountModel>(account);

        _db.Accounts.Update(mappedResults);

        var isSuccess = await _db.SaveChangesAsync();

        return isSuccess == 1 ? account : new AccountDto();
    }

    public async Task<bool> DeleteAccountAsync(int accountId)
    {
        var isAvailable = await _db.Accounts.FirstOrDefaultAsync(a => a.Id == accountId);

        if (isAvailable is null)
            return false;

        _db.Accounts.Remove(isAvailable);

        var isSuccess = await _db.SaveChangesAsync();

        return isSuccess == 1 ? true : false;
    }
}