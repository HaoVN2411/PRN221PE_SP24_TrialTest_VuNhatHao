using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;

namespace Eyeglasses_VuNhatHao.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly UnitOfWork _unitOfWork;

        [BindProperty]
        public RequestLoginModel RequestLoginModel { get; set; }

        public IndexModel(ILogger<IndexModel> logger, UnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            var existedAccount = _unitOfWork.StoreAccountRepository.Get(x => 
            x.EmailAddress.Equals(RequestLoginModel.EmailAddress) 
            && x.AccountPassword.Equals(RequestLoginModel.Password)
            && (x.Role == 1 || x.Role == 2)).FirstOrDefault();

            if (existedAccount != null)
            {
                HttpContext.Session.SetString("Email", existedAccount.EmailAddress);
                HttpContext.Session.SetString("Role", existedAccount.Role.ToString());
                return RedirectToPage("/EyeGlass");
            }

            else
            {
                ModelState.AddModelError(string.Empty, "You do not have permission to do this function!");
                return Page();
            }


        }

    }
}