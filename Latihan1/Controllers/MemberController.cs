using Latihan1.DAO;
using Latihan1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Latihan1.Controllers
{
    public class MemberController : Controller
    {
        MemberDAO _dao;
        public MemberController()
        {
            _dao = new MemberDAO();
        }
        public IActionResult Index()
        {
            List<MemberModel> members = _dao.GetAllMember();
            ViewBag.members = members;
            return View();
        }

        [HttpPost]
        public IActionResult Create(MemberModel membermodel)
        {
            bool simpan =_dao.InsertMember(membermodel);
            if (simpan)
            {
                TempData["success_message"] = "Berhasil memasukkan data";
            }
            else
            {
                TempData["error_message"] = "Gagal memasukkan data";
            }

            return Json(membermodel);
        }   

        public IActionResult Edit(int id)
        {
            MemberModel member = _dao.GetMemberById(id);
            return View(member);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(MemberModel memberData)
        {
            
            bool insert = _dao.UpdateMember(memberData);
            if (insert)
            {
                TempData["success_message"] = "Berhasil memperbarui data";
            }
            else
            {
                TempData["error_message"] = "Gagal memperbarui data";
            }

            return Redirect("/Member/Edit/" + memberData.Id);
        }

       

        public JsonResult Delete(int id)
        {
            bool result = _dao.DeleteMember(id);
            return Json(result);
                
        }
    }
}
