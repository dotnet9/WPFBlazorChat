using Prism.Mvvm;
using Prism.Navigation;

namespace WPFBlazorChat.Core.Mvvm;
public abstract class ViewModelBase : BindableBase, IDestructible
{
    protected ViewModelBase()
    {

    }

    public virtual void Destroy()
    {

    }
}
