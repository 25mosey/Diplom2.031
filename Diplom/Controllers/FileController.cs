using Microsoft.AspNetCore.Mvc;
using Diplom.Models;
using System.Collections.Generic;
using System.Linq;

namespace Diplom.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FileController : ControllerBase
    {
        private static readonly List<FileSystemItem> FileSystem = new List<FileSystemItem>
        {
            new FileSystemItem
            {
                Name = "Documents",
                Type = "folder",
                Contents = new List<FileSystemItem>
                {
                    new FileSystemItem
                    {
                        Name = "Projects",
                        Type = "folder",
                        Contents = new List<FileSystemItem>
                        {
                            new FileSystemItem { Name = "project1.txt", Type = "file" },
                            new FileSystemItem { Name = "project2.txt", Type = "file" }
                        }
                    },
                    new FileSystemItem { Name = "resume.pdf", Type = "file" }
                }
            },
            new FileSystemItem
            {
                Name = "Photos",
                Type = "folder",
                Contents = new List<FileSystemItem>
                {
                    new FileSystemItem { Name = "vacation.jpg", Type = "file" }
                }
            }
        };

        [HttpGet]
        public ActionResult<IEnumerable<FileSystemItem>> GetFileSystem()
        {
            return Ok(FileSystem);
        }

        [HttpPost]
        public ActionResult AddItem([FromBody] FileSystemItem newItem)
        {
            FileSystem.Add(newItem);
            return Ok();
        }

        [HttpDelete("{name}")]
        public ActionResult DeleteItem(string name)
        {
            var item = FindItem(FileSystem, name);
            if (item == null) return NotFound();
            FileSystem.Remove(item);
            return Ok();
        }

        private FileSystemItem FindItem(List<FileSystemItem> items, string name)
        {
            foreach (var item in items)
            {
                if (item.Name == name) return item;
                if (item.Type == "folder")
                {
                    var found = FindItem(item.Contents, name);
                    if (found != null) return found;
                }
            }
            return null;
        }
    }
}