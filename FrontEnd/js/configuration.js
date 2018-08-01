const options = {
    year: "numeric", month: "2-digit",
    day: "2-digit", hour: "2-digit", minute: "2-digit"
};
console.log("paso seteo");
const regionalConfiguration = "en-US";

const servicesUrl = "http://localhost:5387";

const accountUrl = `${servicesUrl}/api/Accounts`;

const eventsUrl = `${servicesUrl}/api/Events`;

const guestsUrl = `${servicesUrl}/api/guests`;

const invitationsUrl = `${servicesUrl}/api/invitations`;