using System.Threading.Tasks;

namespace DvachBrowser4.Core.Lifetime
{
    /// <summary>
    /// ���������� ������� �� ������������� ���������.
    /// </summary>
    /// <param name="sender">�����������.</param>
    /// <param name="lifetimeState">���������.</param>
    /// <returns>����.</returns>
    public delegate ValueTask<Nothing> LifetimeStateChangedEventHandler(object sender, LifetimeState lifetimeState);
}