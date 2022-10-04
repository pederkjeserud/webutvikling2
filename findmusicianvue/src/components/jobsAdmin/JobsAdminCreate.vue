<template>
    
    <header>
        <h3>Legg til nytt oppdrag</h3>
    </header>

    <section class="card" >
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
            <input class="btn btn-primary" @click="postJob" type="button" value="Publiser oppdrag">
        </div>
    </section>


</template>

<script>
import axios from 'axios'
import { reactive, toRefs } from 'vue'

export default {
    setup() {


        const jobInput = reactive(
            { 
                title: "", 
                eventType: "", 
                maxPrice: "", 
                description: "" ,
                name: "",
                email: "",
                phoneNumber: ""
            });


        // Gjør axios postkall til controller (post-metoden) for å lagre nytt oppdrag i databasen.

        const postJob = () => {

            const newJob = {

                title: jobInput.title,
                eventType: jobInput.eventType,
                maxPrice: parseInt( jobInput.maxPrice ),
                description: jobInput.description,
                name: jobInput.name,
                email: jobInput.email,
                phoneNumber: jobInput.phoneNumber

            }

            axios.post( "https://localhost:5001/event/", newJob )

                
        }

        return { 
            ...toRefs( jobInput ),  
            postJob          
        }
        
    }
}
</script>