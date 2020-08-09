using System;
using System.Collections.Generic;
using System.Text;
using Ninject.Extensions.Factory;
using Ninject.Modules;
using RubiksCubeAlgorithms.WPF.ViewModels;
using RubiksCubeAlgorithms.WPF.ViewModelServices.Interfaces;
using RubiksCubeAlgorithms.WPF.ViewModelServices.Mock;

namespace RubiksCubeAlgorithms.WPF
{
    public class IocConfiguration : NinjectModule
    {
        public override void Load()
        {
            Bind<IMainWindowService>().To<MockMainWindowService>().InTransientScope();
            Bind<IMethodViewModelFactory>().ToFactory();

            Bind<IMethodService>().To<MockMethodService>().InTransientScope();
            Bind<IStepViewModelFactory>().ToFactory();

            Bind<IStepService>().To<MockStepService>().InTransientScope();
            Bind<ICaseViewModelFactory>().ToFactory();

            Bind<ICaseService>().To<MockCaseService>().InTransientScope();
        }
    }
}
