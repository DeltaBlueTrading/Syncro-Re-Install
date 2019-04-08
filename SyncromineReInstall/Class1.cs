using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Threading;
using System.Diagnostics;

namespace EmailMponengManagers
{
    public static class Class1
    {

        public static Task WaitForExitAsync(this Process process,
CancellationToken cancellationToken = default(CancellationToken))
        {
            var tcs = new TaskCompletionSource<object>();
            process.EnableRaisingEvents = true;
            if (process.HasExited)
            { tcs.TrySetResult(null); }
            if (cancellationToken != default(CancellationToken))
                cancellationToken.Register(() => { tcs.TrySetCanceled(); });

            if (process.HasExited)
            { tcs.TrySetResult(null);
                
            }

            return tcs.Task;
        }


    }


 
}
