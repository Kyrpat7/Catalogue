using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Stasiewski.Catalogue.Interfaces;
using System.Collections.ObjectModel;
using Stasiewski.Catalogue.Core;

namespace Stasiewski.Catalogue.WPFWindow
{
    public class GraphicCardViewModel : ViewModelBase
    {
        private IGraphicCard _card;

        public GraphicCardViewModel()
        {
        }

        public GraphicCardViewModel(IGraphicCard graphicCard)
        {
            _card = graphicCard;
            _producers = new ObservableCollection<IProducer>(Products.GlobalQuery.getProducers());
        }

        private ObservableCollection<IProducer> _producers;
        public ObservableCollection<IProducer> Producers
        {
            get => _producers;
        }

        [Required(ErrorMessage = "Model must be set.")]
        public String Model
        {
            get { return _card.Model; }
            set
            {
                _card.Model = value;
                OnPropertyChanged("Model");
                Validate();
            }
        }

        [Required(ErrorMessage = "Series must be specified.")]
        public string Series
        {
            get => _card.Series;

            set
            {
                _card.Series = value;
                OnPropertyChanged("Series");
                Validate();
            }
        }

        [Required(ErrorMessage = "Memory size must be specified.")]
        [Range(1, 10000000, ErrorMessage ="Rozmiar pamięci powinien mieścić się w przedziale 1 - 10000000.")]
        public int Memory
        {
            get => _card.Memory;

            set
            {
                _card.Memory = value;
                OnPropertyChanged("Memory");
                Validate();
            }
        }

       [Required(ErrorMessage = "DirectX version support must be specified.")]
        public DirectXVersion DirectXSupport
        {
            get => _card.DirectXSupport;
            set
            {
                _card.DirectXSupport = value;
                OnPropertyChanged("DirectXSupport");
                Validate();
            }
        }

        [Required(ErrorMessage = "Producer must be specified.")]
        public IProducer Producer
        {
            get => _card.Producer;

            set
            {
                _card.Producer = value;
                OnPropertyChanged("Producer");
                Validate();
            }
        }

        public void Validate()
        {
            var validationContext = new ValidationContext(this, null, null);
            var validationResults = new List<ValidationResult>();

            Validator.TryValidateObject(this, validationContext, validationResults, true);

            foreach (var kv in _errors.ToList())
            {
                if (validationResults.All(r => r.MemberNames.All(m => m != kv.Key)))
                {
                    _errors.Remove(kv.Key);
                    OnErrorChanged(kv.Key);
                }
            }

            var q = from e in validationResults
                    from m in e.MemberNames
                    group e by m into g
                    select g;

            foreach (var prop in q)
            {
                var messages = prop.Select(r => r.ErrorMessage).ToList();

                if (_errors.ContainsKey(prop.Key))
                {
                    _errors.Remove(prop.Key);
                }
                _errors.Add(prop.Key, messages);
                OnErrorChanged(prop.Key);
            }
        }
    }
}
