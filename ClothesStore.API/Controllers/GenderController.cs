﻿using ClothesStore.API.Common;
using ClothesStrore.Application.Gender.GetGenders;
using ClothesStrore.Application.Gender.InsertGender;
using ClothesStrore.Application.Genders.DeleteGender;
using ClothesStrore.Application.Genders.UpdateGender;
using Microsoft.AspNetCore.Mvc;
namespace ClothesStore.API.Controllers
{
    [Route("api/gender")]
    [ApiController]
    public class GenderController : ApiControllerBase
    {
        [HttpGet("getGenders")]
        public async Task<ActionResult> GetAllGenders()
        {
            var response = await Mediator.Send(new GetAllGendersRequest());
            return Ok(response);
        }
        [HttpPost("insert")]
        public async Task<ActionResult> CreateGender([FromBody] CreateGenderRequest payload)
        {
            var result = await Mediator.Send(payload);
            var jsonObject = Deserialize.JsonDeserialize(result);
            jsonObject.TryGetValue("Message", out string messageValue);
            if (messageValue != null)
                return Ok(jsonObject);
            else
                return BadRequest();
        }
        [HttpPut("update")]
        public async Task<ActionResult> UpdateGender(string id, [FromBody] UpdateGenderRequest request)
        {
            var updateCommand = new UpdateGenderCommand
            {
                Id = id,
                UpdateRequest = request
            };

            var result = await Mediator.Send(updateCommand);

            return Ok(Deserialize.JsonDeserialize(result));
        }
        [HttpPut("delete")]
        public async Task<ActionResult> DeleteGender([FromBody] DeleteGenderRequest request)
        {
            var result = await Mediator.Send(request);
            return Ok(Deserialize.JsonDeserialize(result));
        }
    }
}
