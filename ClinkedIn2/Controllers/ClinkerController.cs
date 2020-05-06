﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinkedIn2.DataAccess;
using ClinkedIn2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinkedIn2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinkerController : ControllerBase
    {
        private ClinkerRepository _repository = new ClinkerRepository();

        [HttpGet]
        public IActionResult GetAllClinkers()
        {
            var allClinkers = _repository.GetAll();
            return Ok(allClinkers);
        }

        [HttpPost]
        public IActionResult AddClinker(Clinker clinkerToAdd)
        {
            var existingClinker = _repository.GetById(clinkerToAdd.Id);
            if (existingClinker == null)
            {
                _repository.Add(clinkerToAdd);
                return Created("", clinkerToAdd);
            }
            else
            {
                return NotFound("Yo this didn't work");
            }
        }

        [HttpGet("{clinkerId}/interests")]
        public IActionResult ReturnClinkerInterest(int clinkerId)
        {
            var selectedClinker = _repository.GetById(clinkerId);
            return Ok(selectedClinker.Interests);
        }

        [HttpPost("{clinkerId}/interests")]
        public IActionResult AddClinkerInterest(int clinkerId, [FromBody] string interest)
        {
            var selectedClinker = _repository.GetById(clinkerId);
            _repository.AddInterest(selectedClinker, interest);
            return Ok($"Congratulations! You are now interested in {interest}.");
        }

        [HttpGet]
        public IActionResult GetAllClinkers()
        {
            var allClinkers = _repository.GetAll();
            return Ok(allClinkers);
        }

        [HttpGet("{service}/clinkers")]
        public IActionResult GetAllClinkersByService(string service)
        {
            var clinkersByService = _repository.showAllClinkersByService(service);
            return Ok(clinkersByService);
        }

        // Friend Methods
        [HttpGet("{id}/friends")]
        public IActionResult GetClinkersFriendsById(int id)
        {
            var clinkerFriends = _repository.getFriendsOfClinker(id);
            return Ok(clinkerFriends);
        }

        // Get Friends of Friends
        [HttpGet("{id}/friends/friendsOfFriends")]
        public IActionResult GetClinkersFriendsOfFriends(int id)
        {
            var clinkerFriendsOfFriends = _repository.getFriendsOfFriends(id);
            return Ok(clinkerFriendsOfFriends);
        }

        //api/clinker/addfriend/2
        [HttpPost("{currentUserId}/friends")]
        public IActionResult AddClinkerToFriendsList(Clinker friendToAddd, int currentUserId)
        {
            var friendsListPlusNewFriend = _repository.AddFriend(friendToAddd, currentUserId);
            return Ok(friendsListPlusNewFriend);
        }

        [HttpDelete("{currentUserId}/friends")]
        public IActionResult DeleteClinkerFromFriends(Clinker friendToDelete, int currentUserId)
        {
            var friendsListMinusBadFriend = _repository.DeleteFriend(friendToDelete, currentUserId);
            return Ok(friendsListMinusBadFriend);
        }

        // Enemy Methods
        [HttpGet("{id}/enemies")]
        public IActionResult GetClinkersEnemiesById(int id)
        {
            var clinkerEnemies = _repository.getEnemiesOfClinker(id);
            return Ok(clinkerEnemies);
        }

        [HttpPost("{currentUserId}/enemies")]
        public IActionResult AddClinkerToEnemiesList(Clinker enemyToAdd, int currentUserId)
        {
            var enemiesListPlusNewEnemy = _repository.AddEnemy(enemyToAdd, currentUserId);
            return Ok(enemiesListPlusNewEnemy);
        }

        [HttpDelete("{currentUserId}/enemies")]
        public IActionResult DeleteClinkerFromEnemies(Clinker enemyToDelete, int currentUserId)
        {
            var enemiesListMinusGoodEnemy = _repository.DeleteEnemy(enemyToDelete, currentUserId);
            return Ok(enemiesListMinusGoodEnemy);
        }


    }
}
