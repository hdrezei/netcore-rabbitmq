﻿using nyom.domain.core.EntityFramework.Models;

namespace nyom.domain.Crm.Empresa
{
	public class EmpresaService : ServiceBase<Empresa>, IEmpresaService
	{
		private readonly IEmpresaRepository _empresaRepository;
		public EmpresaService(IEmpresaRepository empresaRepository) : base(empresaRepository)
		{
			_empresaRepository = empresaRepository;
		}
	}
}