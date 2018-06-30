using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace Stasiewski.Catalogue.WPFWindow
{
    public class GraphicCardListViewModel : ViewModelBase
    {
        #region carsCollection
        private ObservableCollection<GraphicCardViewModel> _cards;

        public ObservableCollection<GraphicCardViewModel> Cards
        {
            get => _cards;
            set
            {
                _cards = value;
                OnPropertyChanged("Cards");
            }
        }
        #endregion

        private ListCollectionView _view;

        public GraphicCardListViewModel()
        {
            _cards = new ObservableCollection<GraphicCardViewModel>();
            _view = (ListCollectionView)CollectionViewSource.GetDefaultView(_cards);
            GetAllCars();
            _filterCommand = new RelayCommand(param => this.FilterData());
            _createNewCardCommand = new RelayCommand(param => this.CreateNewCard(), param => this.CanCreateCard());
            FilterString = "";
        }

        private void GetAllCars()
        {
            foreach (var c in Products.GlobalQuery.getProducts())
            {
                _cards.Add(new GraphicCardViewModel(c));
            }
        }

        public string FilterString
        { get; set; }

        private ICommand _filterCommand;

        public ICommand FilterCommand
        {
            get => _filterCommand;
        }

        private void FilterData()
        {
            if (!String.IsNullOrEmpty(FilterString))
            {
                _view.Filter = (c) => ((GraphicCardViewModel)c).Model.Contains(FilterString);
            }
            else
            {
                _view.Filter = null;
            }
        }

        private GraphicCardViewModel _editedCard;
        public GraphicCardViewModel EditedCard
        {
            get => _editedCard;
            set
            {
                _editedCard = value;
                OnPropertyChanged(nameof(EditedCard));
            }
        }

        private RelayCommand _createNewCardCommand;
        public RelayCommand CreateNewCardCommand
        {
            get => _createNewCardCommand;
        }

        private void CreateNewCard()
        {
            EditedCard = new GraphicCardViewModel(Products.GlobalQuery.CreateNewProduct());
            _cards.Add(EditedCard);
            EditedCard.Validate();
        }
        private bool CanCreateCard()
        {
            if (this.EditedCard == null)
                return true;
            else if (!this.EditedCard.HasErrors)
                return true;

            return false;
        }

    }
}
