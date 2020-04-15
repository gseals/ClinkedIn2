using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinkedIn2.Models;

namespace ClinkedIn2.DataAccess
{
    public class ClinkerRepository
    {
        private static List<Clinker> _clinkers = new List<Clinker>()
        {
            new Clinker()
            {
                Id = 1,
                Name = "Moose",
                Interests = {"water", "earth"},
                Services =
                {
                    new LineItem
                    {
                        Service = "mud",
                    }
                },
                Friends =
                {
                    new Clinker()
                    {
                        Id = 2,
                        Name = "Monty",
                        Interests = {"fire", "heart"},
                        Services =
                        {
                            new LineItem()
                            {
                                Service = "punchies",
                            }
                        },
                        Friends =
                        {
                            new Clinker()
                            {
                                Id = 3,
                                Name = "Mashy",
                                Interests = {"wind", "space"},
                                Services =
                                {
                                    new LineItem
                                    {
                                        Service = "Mottos are dangerous"
                                    }
                                }
                            }
                        }
                    }
                },
                Enemies =
                {
                    new Clinker()
                    {
                        Id = 4,
                        Name = "malted",
                        Interests = {"candies", "other candies"},
                        Services =
                        {
                            new LineItem()
                            {
                                Service = "making candy"
                            }
                        },

                    }
                }
            }
        };

        public List<Clinker> GetAll()
        {
            return _clinkers;
        }

    }
}
