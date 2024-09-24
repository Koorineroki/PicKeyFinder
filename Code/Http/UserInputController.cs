using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PicKeyFinder.Code.Core;

namespace PicKeyFinder.Code.Http
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInputController : ControllerBase
    {
        private readonly TaskDistributor _taskDistributor;

        public UserInputController(TaskDistributor taskDistributor)
        {
            _taskDistributor = taskDistributor; // 使用单例实例
        }

        // POST: api/UserInput
        [HttpPost]
        public IActionResult ProcessUserInput([FromBody] UserInputModel inputData)
        {
            try
            {
                if (inputData == null || string.IsNullOrEmpty(inputData.InputText))
                {
                    return BadRequest("Invalid input.");
                }

                // 在这里处理用户输入数据
                string processedText = _taskDistributor.AssignTask(inputData.InputText);

                // 返回处理后的结果
                return Ok(new { ProcessedText = processedText });
            }
            catch (BadHttpRequestException ex)
            {
                // 处理 BadHttpRequestException
                return StatusCode(400);
            }
            catch (Exception ex)
            {
                // 捕捉其他异常
                return StatusCode(500);
            }

        }
    }

    // 定义用于接收用户输入的模型
    public class UserInputModel
    {
        public string InputText { get; set; }
    }
}