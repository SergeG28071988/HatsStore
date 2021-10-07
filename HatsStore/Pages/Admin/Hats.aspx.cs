using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HatsStore.Models;
using HatsStore.Models.Repository;
using System.Web.ModelBinding;

namespace HatsStore.Pages.Admin
{
    public partial class Hats : System.Web.UI.Page
    {
        private Repository repository = new Repository();
        protected void Page_Load(object sender, EventArgs e)
        {
        }      

        public IEnumerable<Hat> GetHats()
        {
            return repository.Hats;
        }

        public void UpdateHat(int HatID)
        {
            Hat myHat = repository.Hats
                .Where(p => p.HatId == HatID).FirstOrDefault();
            if (myHat != null && TryUpdateModel(myHat, new FormValueProvider(ModelBindingExecutionContext)))
            {
                repository.SaveHat(myHat);
            }
        }

        public void DeleteHat(int HatID)
        {
            Hat myHat = repository.Hats
                 .Where(p => p.HatId == HatID).FirstOrDefault();
            if (myHat != null)
            {
                repository.DeleteHat(myHat);
            }
        }

        public void InsertHat() 
        {
            Hat myHat = new Hat();
            if (TryUpdateModel(myHat, new FormValueProvider(ModelBindingExecutionContext)))
            {
                repository.SaveHat(myHat);
            }
        }
    }
}