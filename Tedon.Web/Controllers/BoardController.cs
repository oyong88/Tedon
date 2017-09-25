using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tedon.Web.Data;
using Tedon.Web.Models;
using Tedon.Web.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;

namespace Tedon.Web.Controllers
{
    
    public class BoardController : BaseController
    {
        /// <summary>
        /// �Խ��� 
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var boardService = new BoardService();
            var boardList = boardService.List();

            return View(boardList);
        }

        /// <summary>
        /// �۾���
        /// </summary>
        /// <returns></returns>
        public IActionResult Write()
        {
            return View();
        }

        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        public IActionResult Edit(int id)
        {
            var boardService = new BoardService();

            var board = boardService.Get(id);

            if(board == null)
            {
                return NotFound();
            }

            return View(board);
        }

        /// <summary>
        /// �Է� API
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Add(Board board)
        {
            var boardService = new BoardService();
            int result = boardService.Add(board);

            return Json(new
            {
                code = 0,
                message = "OK"
            });
        }

        /// <summary>
        /// ���� API
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Edit(Board board)
        {
            var boardService = new BoardService();
            int result = boardService.Update(board);

            return Json(new
            {
                code = 0,
                message = "OK"
            });
        }

        /// <summary>
        /// ���� API
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var boardService = new BoardService();
            int result = boardService.Delete(id);

            return Json(new
            {
                code = 0,
                message = "OK"
            });
        }
    }
}