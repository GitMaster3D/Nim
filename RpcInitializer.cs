using System;

public static class RpcInitializer
{
    public static void Initialize(M)
    {
        _rpcList.Add(() =>
        {
            MethodInvoker inv = delegate
            {
                connectedLabel.Text = "Connected";
            };

            _inputIpTextbox.Invoke(inv);
        });
    }
}
