using System;
using System.Windows.Forms;

namespace StudentsFetcher.StudentMarking
{
    public partial class ucComponentMark : UserControl
    {
        const int LowMark = 40;
        const int HighMark = 80;

        public int Id = -1;

        public bool IsSet
        {
            get
            {
                return !checkBox1.Checked;
            }
        }

        public void Unset()
        {
            MarkValue = LowMark;
            SetRange(LowMark, HighMark);
            checkBox1.Checked = true;
        }

        public void flipRange()
        {
            if (tbComponentMark.Minimum == 0)
                SetRange(LowMark, HighMark);
            else
                SetRange(0, 100);
        }

        private void SetRange(int minimum, int maximum)
        {
            if (_MarkValue >= minimum && _MarkValue <= maximum)
            {
                tbComponentMark.Minimum = minimum;
                tbComponentMark.Maximum = maximum;
            }
        }

        private int _MarkValue;
        public int MarkValue
        {
            get
            {
                return _MarkValue;
            }
            set
            {
                _MarkValue = value;
                checkBox1.Checked = false;
                lblMark.Text = value.ToString();
                try
                {
                    tbComponentMark.Value = value;
                }
                catch (Exception)
                {
                    SetRange(0, 100);
                    tbComponentMark.Value = value;
                }
                
            }
        }

        public string ComponentName
        {
            get
            {
                return lblDesc.Text;
            }
            set
            {
                lblDesc.Text = value;
            }
        }

        public ucComponentMark()
        {
            InitializeComponent();
        }

        private void tbComponentMark_ValueChanged(object sender, EventArgs e)
        {
            _MarkValue = tbComponentMark.Value;
            lblMark.Text = _MarkValue.ToString();
        }

        private void lblDesc_Click(object sender, EventArgs e)
        {
            flipRange();
        }

        //Delegate that will be the pointer for the event, contains two arguments 
        //sender (object that raised it) and OperationEventArgs for the event arguments
        public delegate void ChangeHappened(object sender, EventArgs? e);
        //Event name 
        public event ChangeHappened? onUserChange;  

        private void tbComponentMark_Scroll(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            onUserChange?.Invoke(this, e);            
        }
    }
}
