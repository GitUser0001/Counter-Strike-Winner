using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CounterStrike.ViewModel;

namespace CounterStrike.Model
{
    public enum HealthType
    {
        Full = 100,
        OneShoot = 80,
        TwoShoot = 60,
        ThreeShoot = 50,
        FourShoot = 25,
        Zero = 0,
        None
    }

    public class Health : ViewModelBase
    {
        private string _fullImage = "pack://application:,,,/Media/Health/health5.png";
        private string _oneShootImage = "pack://application:,,,/Media/Health/health4.png";
        private string _twoShootImage = "pack://application:,,,/Media/Health/health3.png";
        private string _threeShootImage = "pack://application:,,,/Media/Health/health2.png";
        private string _fourShootImage = "pack://application:,,,/Media/Health/health1.png";
        private string _zeroImage = "pack://application:,,,/Media/Health/health0.png";

        private int _count;
        private string _photo;

        public Health(int count)
        {
            this.Count = count;

            this.TypeHealth = this.SetCountDamage(this.Count);
            this.Photo = this.SetTypeOfHealth(this.TypeHealth);
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

                    // SET THE IMAGE BY DAMANGE
                    this._photo = this.SetPhotoByDamage(this._count);
                    this.OnPropertyChanged("Photo");
                    this.OnPropertyChanged("Count");
                }
                if (value <= -1)
                {
                    this._count = 0;
                    this.OnPropertyChanged("Count");
                    this.OnPropertyChanged("Photo");
                }
            }
        }
        public HealthType TypeHealth { get; set; }

        public string SetPhotoByDamage(int count)
        {
            this.TypeHealth = this.SetCountDamage(count);
            return this.SetTypeOfHealth(this.TypeHealth);
        }

        private string SetTypeOfHealth(HealthType type)
        {
            switch (type)
            {
                case HealthType.Full:
                    return _fullImage;
                case HealthType.OneShoot:
                    return _oneShootImage;
                case HealthType.TwoShoot:
                    return _twoShootImage;
                case HealthType.ThreeShoot:
                    return _threeShootImage;
                case HealthType.FourShoot:
                    return _fourShootImage;
                case HealthType.Zero:
                    return _zeroImage;
                default:
                    return _zeroImage;
            }
        }

        private HealthType SetCountDamage(int count)
        {
            HealthType type = HealthType.None;
            if (count == 100)
                type = HealthType.Full;
            else if (count >= 80 && count <= 99)
                type = HealthType.OneShoot;
            else if (count >= 60 && count <= 79)
                type = HealthType.TwoShoot;
            else if (count >= 40 && count <= 59)
                type = HealthType.ThreeShoot;
            else if (count >= 20 && count <= 39)
                type = HealthType.FourShoot;
            else if (count >= 0 && count <= 19)
                type = HealthType.Zero;
            return type;
        }
    }
}
