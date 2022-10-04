<template>
    
    <header>
        <h3>Slett oppdrag</h3>
    </header>

    <section class="card" >
        <div>
            <label class="form-label" for="">Id</label>
            <input v-model="id" type="text">
            <button class="btn btn-secondary" @click="getJobById">Hent oppdrag</button>
        </div>

        <h4>Id: {{ id }}</h4>
        <h5>Tittel: {{ title }}</h5>
        <p>Type oppdrag: {{ eventType }}</p>
        <p>Beskrivelse: {{ description }}</p>
        <h4>Kontaktinfo:</h4>
        <p>Navn{{ name }}</p>
        <p>Epost: {{ email }}</p>
        <p>Tlf: {{ phoneNumber }}</p>
       
        <div>
            <input class="btn btn-danger" @click="deleteJob" type="button" value="Slett oppdrag">
        </div>
    </section>


</template>

<script>
import axios from 'axios'
import { reactive, toRefs } from 'vue'

export default {
    setup() {


        let jobObject = reactive(
            { 
                id: "",
                title: "", 
                eventType: "", 
                maxPrice: "", 
                description: "" ,
                name: "",
                email: "",
                phoneNumber: ""
            });

        // Henter inn oppdrag basert på id, ved hjelp av Get-metode i controller
    
        const getJobById = () => {
            axios(`https://localhost:5001/event/${jobObject.id}`)
                .then( response => {

                    jobObject.title = response.data.title;
                    jobObject.eventType = response.data.eventType;
                    jobObject.maxPrice = response.data.maxPrice;
                    jobObject.description = response.data.description;
                    jobObject.name = response.data.name;
                    jobObject.email = response.data.email;
                    jobObject.phoneNumber = response.data.phoneNumber;

                } )
        }

        // Gjør axios delete til controller (delete-metoden) for å slette oppdrag i databasen.

        const deleteJob = () => {

            const deletedJob = {
                id: parseInt( jobObject.id ),
                title: jobObject.title,
                eventType: jobObject.eventType,
                maxPrice: parseInt( jobObject.maxPrice ),
                description: jobObject.description,
                name: jobObject.name,
                email: jobObject.email,
                phoneNumber: jobObject.phoneNumber

            }

            axios.delete( `https://localhost:5001/event/${deletedJob.id}`, deletedJob )
   
        }

        return { 
            getJobById,
            ...toRefs( jobObject ),  
            deleteJob          
        }
        
    }
}
</script>