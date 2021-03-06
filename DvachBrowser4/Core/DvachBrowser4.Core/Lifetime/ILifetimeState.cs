using System;

namespace DvachBrowser4.Core.Lifetime
{
    /// <summary>
    /// ���������� � ��������� ������� �����.
    /// </summary>
    public interface ILifetimeState
    {
        /// <summary>
        /// ��������� ������� �����.
        /// </summary>
        LifetimeState LifetimeState { get; }

        /// <summary>
        /// ��������� ����������.
        /// </summary>
        event LifetimeStateChangedEventHandler LifetimeStateChanged;
    }
}