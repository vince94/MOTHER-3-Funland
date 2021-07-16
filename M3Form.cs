using System.Windows.Forms;

namespace MOTHER3Funland
{
    public interface IM3Form
    {
        void SelectIndex(int[] index);
        int[] GetIndex();
    }

    public class M3Form : Form, IM3Form
    {
        public M3Form()
        {
            this.FormClosing += new FormClosingEventHandler(ModuleArbiter.FormClosing);
        }

        public virtual void SelectIndex(int[] index)
        {
        }

        public virtual int[] GetIndex()
        {
            return null;
        }
    }
}
