using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyHealthChart3.Models
{
    public enum DoctorType
    {
        Allergist, Audiologist, Anesthesiologist, [Display(Name = "Breast Cancer Specialist")] BreastCancerSpecialist,
        Cardiologist, Chiropractor, Dentist, Dermatologist, Dietitian, Endocrinologist,
        [Display(Name = "ENT Specialist")] ENTspecialist, [Display(Name = "ER Physician")] ERphysician,
        [Display(Name = "Fertility Specialist")] Fertility, Gastroenterologist, Geriatric,
        Immunologist, [Display(Name = "Infectious Disease Specialist")] Disease,
        [Display(Name = "Internal Medicine Specialist")] InternalMedicine,
        [Display(Name = "Medical Geneticist")] Genetic, Nephrologist, Nutritionist,
        Neurologist, Neurosurgeon, [Display(Name = "OB-GYN")] OBGYN, [Display(Name = "Occupational Therapist")] Occupational,
        Oncologist, Ophthalmologist, Optometrist, [Display(Name = "Oral Surgeon")] Oral,
        [Display(Name = "Orthopedic Surgeon")] Orthopedic, [Display(Name = "Pain Medicine")] Pain,
        Pediatrician, [Display(Name = "Physical Trainer")] Physical,
        [Display(Name = "Primary Care Physician")] PCP, [Display(Name = "Plastic Surgeon")] Plastic,
        Podiatrist, Psychiatrist, Psychologist, Pulmonologist, Radiologist,
        Rheumatologist, Surgeon, Urologist, [Display(Name = "Vascular Surgeon")] Vascular, Veterinarian
    }
    public enum State
    {
        AL, AK, AZ, AR, CA, CO, CT, DE, FL,
        GA, HI, ID, IL, IN, IA, KS, KY, LA,
        ME, MD, MA, MI, MN, MS, MO, MT, NE,
        NV, NH, NJ, NM, NY, NC, ND, OH, OK,
        OR, PA, RI, SC, SD, TN, TX, UT, VT,
        VA, WA, WV, WI, WY
    }
    class Enumerables
    {
    }
}
