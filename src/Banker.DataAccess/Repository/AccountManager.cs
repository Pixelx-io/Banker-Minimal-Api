using Banker.DataAccess.Repository.IRepository;

namespace Banker.DataAccess.Repository;

public class AccountManager : IAccountManager
{
    private readonly ApplicationDbContext _db;
    private readonly IMapper _mapper;

    public AccountManager(ApplicationDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<AccountDto> GetAccountByIdAsync(int id)
    {
        var accountFromDb = await _db.Accounts.FirstOrDefaultAsync(x => x.Id == id);

        var mappedModel = _mapper.Map<AccountDto>(accountFromDb);

        return mappedModel;
    }

    public async Task<AccountDto> GetAccountByEmailAsync(string email)
    {
        throw new NotImplementedException();
    }

    public async Task<AccountDto> InsertAccountAsync(AccountDto account)
    {
        throw new NotImplementedException();
    }

    public async Task<AccountDto> UpdateAccountAsync(AccountDto account)
    {
        throw new NotImplementedException();
    }

    public async Task<AccountDto> DeleteAccountAsync(int id)
    {
        throw new NotImplementedException();
    }
}