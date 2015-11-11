using System.Collections.Generic;

namespace Model.ViewModels
{
    public class TripOptionViewModels
    {
        public TripOptionViewModels()
        {
            TripOptionViewModelCollection = new List<TripOptionViewModel>();
        }

        public ICollection<TripOptionViewModel> TripOptionViewModelCollection { get; set; }
    }
}
