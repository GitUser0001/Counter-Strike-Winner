using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CounterStrike.ViewModel;

namespace CounterStrike.Model
{
    public class Bullet : ViewModelBase
    {
        private int _count;
        private string _photo;

        public Bullet()
        {
            this._photo = "pack://application:,,,/Media/Bullet/bulletTop.png";
        }

        public string Photo
        {
            get
            {
                return _photo;
            }
            set
            {
                if (value != this._photo)
                {
                    this._photo = value;
                    this.OnPropertyChanged("Photo");
                }
            }
        }

        public int Count
        {
            get
            {
                return _count;
            }
            set
            {
                if (value != this._count)
                {
                    this._count = value;
                    this.OnPropertyChanged("Count");
                }
                if(value <= -1)
                {
                    this._count = 0;
                    this.OnPropertyChanged("Count");
                }
            }
        }
    }
}
