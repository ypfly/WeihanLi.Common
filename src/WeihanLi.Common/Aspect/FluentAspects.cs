﻿using System;

namespace WeihanLi.Common.Aspect
{
    public sealed class FluentAspects
    {
        public static readonly FluentAspectOptions AspectOptions;

        static FluentAspects()
        {
            AspectOptions = new FluentAspectOptions();
            // register built-in necessary interceptors
            AspectOptions.InterceptAll()
                .With<TryInvokeInterceptor>();
            AspectOptions.InterceptMethod<IDisposable>(m => m.Dispose())
                .With<DisposableInterceptor>();
        }

        public static void Configure(Action<FluentAspectOptions> optionsAction)
        {
            optionsAction?.Invoke(AspectOptions);
        }
    }
}
