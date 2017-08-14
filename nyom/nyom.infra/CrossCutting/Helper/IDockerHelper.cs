﻿using System;

namespace nyom.infra.CrossCutting.Helper
{
	public interface IDockerHelper
	{
		void Run(Guid dadosCampanhaCampanhaId, string servico);
		void Inspect(string servico);
		void Execute(string servico);
		void CriarContainerDocker(Guid id, string servico);
	}
}