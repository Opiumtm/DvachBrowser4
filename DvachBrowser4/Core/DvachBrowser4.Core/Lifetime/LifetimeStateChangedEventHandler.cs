using System;
using System.Threading.Tasks;
using Windows.ApplicationModel;

namespace DvachBrowser4.Core.Lifetime
{
    /// <summary>
    /// ���������� ������� �� ������������� ���������.
    /// </summary>
    /// <param name="sender">�����������.</param>
    /// <param name="lifetimeState">���������.</param>
    /// <returns>����.</returns>
    public delegate Task LifetimeStateChangedEventHandler(object sender, LifetimeState lifetimeState);
}