﻿using Api.Models.Rest;
using Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("/evaluate")]
    public class EvaluationController : ControllerBase
    {
        private readonly IEvaluationService _evaluationService;

        public EvaluationController(IEvaluationService evaluationService)
        {
            _evaluationService = evaluationService;
        }

        [HttpPost]
        [Route("education-choices")]
        public List<EvaluationResult> EvaluateEducationChoices(AnalyzePostModel analyzePostModel)
        {
            return _evaluationService.EvaluateEducationChoices(analyzePostModel);
        }

    }
}
