﻿using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Veresiye.Data;
using Veresiye.Service;

namespace Veresiye.UI
{
    static class Program
    {
        /// <summary>
        /// Uygulamanın ana girdi noktası.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Autofac = IoC (Inversion-of-control) Provider'ıdır.Bununla dependency injection işlemi kolaylaşır.
            var builder = new ContainerBuilder();
            builder.RegisterType<ApplicationDbContext>().As<ApplicationDbContext>().SingleInstance();

            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>));
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

            //servislerimiz
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<CompanyService>().As<ICompanyService>();
            builder.RegisterType<ActivityService>().As<IActivityService>();

            //formlarımız
            builder.RegisterType<FrmMain>().As<FrmMain>();
            builder.RegisterType<FrmRegister>().As<FrmRegister>();
            builder.RegisterType<FrmCompanies>().As<FrmCompanies>();
            builder.RegisterType<FrmLogin>().As<FrmLogin>();
            builder.RegisterType<FrmCompanyAdd>().As<FrmCompanyAdd>();

            var container = builder.Build();

            using (var scope = container.BeginLifetimeScope())
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                var frm = scope.Resolve<FrmMain>();
                Application.Run(frm);
            }
        }
    }
}
