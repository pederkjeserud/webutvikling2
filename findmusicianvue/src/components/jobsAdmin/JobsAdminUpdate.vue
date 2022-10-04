<template>
    
    <header>
        <h3>Oppdater oppdrag</h3>
    </header>

    <section class="card" >
        <div>
            <label class="form-label" for="">Id</label>
            <input v-model="id" type="text">
            <button class="btn btn-secondary" @click="getJobById">Hent oppdrag</button>
        </div>

        <div>
            <label class="form-label" for="">Tittel</label>
            <input v-model="title" class="form-control" type="text">
        </div>
        <div>
            <label class="form-label" for="">Type oppdrag</label>
            <input v-model="eventType"  class="form-control" type="text">
        </div>
        <div>
            <label class="form-label" for="">Makspris</label>
            <input v-model="maxPrice"  class="form-control" type="text">
        </div>
        <div>
            <label class="form-label" for="">Beskrivelse av oppdrag</label>
            <input v-model="description" class="form-control" type="text" placeholder="Beskriv ditt oppdrag, type musikere, sjanger, osv.">
        </div>
        <h4>Kontaktinfo</h4>
        <div>
            <label class="form-label" for="">Navn</label>
            <input v-model="name"  class="form-control" type="text">
        </div>
        <div>
            <label class="form-label" for="">Epost</label>
            <input v-model="email"  class="form-control" type="text">
        </div>
        <div>
            <label class="form-label" for="">Telefon</label>
            <input v-model="phoneNumber"  class="form-control" type="text">
        </div>
        <div>
            <input class="btn btn-primary" @click="putJob" type="button" value="Lagre endringer">
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

                    console.log( response.data );
                } )
        }

        // Gjør axios put til controller (put-metoden) for å oppdatere oppdrag i databasen.

        const putJob = () => {

            const updatedJob = {
                id: parseInt( jobObject.id ),
                title: jobObject.title,
                eventType: jobObject.eventType,
                maxPrice: parseInt( jobObject.maxPrice ),
                description: jobObject.description,
                name: jobObject.name,
                email: jobObject.email,
                phoneNumber: jobObject.phoneNumber

            }

            axios.put( "https://localhost:5001/event/", updatedJob )

                
        }

        return { 
            getJobById,
            ...toRefs( jobObject ),  
            putJob          
        }
        
    }
}
</script>